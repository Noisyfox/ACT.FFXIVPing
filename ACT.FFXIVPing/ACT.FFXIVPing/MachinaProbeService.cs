using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ACT.FoxCommon;
using FFXIVPingMachina.FFXIVNetwork;
using FFXIVPingMachina.FFXIVNetwork.Packets;
using FFXIVPingMachina.PingMonitor;
using Machina;
using Machina.FFXIV;

namespace ACT.FFXIVPing
{
    class MachinaProbeService : IPluginComponent
    {
        private FFXIVPingPlugin _plugin;
        private bool _isStarted = false;
        private readonly ConcurrentDictionary<uint, ProcessContext> _processContexts = new ConcurrentDictionary<uint, ProcessContext>();

        public void AttachToAct(FFXIVPingPlugin plugin)
        {
            _plugin = plugin;
            plugin.Controller.GameProcessUpdated += ControllerOnGameProcessUpdated;
            plugin.Controller.AdvancedPingEnabled += ControllerOnAdvancedPingEnabled;
        }

        private void ControllerOnAdvancedPingEnabled(bool fromView, bool enabled)
        {
            if (enabled)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        private void ControllerOnGameProcessUpdated(bool fromView, HashSet<uint> pids)
        {
            lock (this)
            {
                if (!_isStarted)
                {
                    return;
                }

                var oldCtx = new HashSet<uint>(_processContexts.Keys);
                oldCtx.ExceptWith(pids);

                foreach (var pid in oldCtx)
                {
                    if (_processContexts.TryRemove(pid, out var ctx))
                    {
                        ctx.Stop();
                    }
                }

                UpdateGameClientVersion();

                foreach (var pid in pids)
                {
                    _processContexts.AddOrUpdate(pid, _pid =>
                    {
                        var ctx = new ProcessContext(_pid);
                        ctx.Start();
                        return ctx;
                    }, (_, _ctx) => _ctx);
                }
            }
        }

        public void PostAttachToAct(FFXIVPingPlugin plugin)
        {
        }

        public int FindTTL(uint pid)
        {
            if (!_isStarted)
            {
                return -1;
            }

            if (_processContexts.TryGetValue(pid, out var ctx))
            {
                return ctx.CurrentTTL;
            }
            return -1;
        }

        private void Start()
        {
            lock (this)
            {
                Stop();
                _isStarted = true;
                _plugin.Controller.NotifyLogMessageAppend(false, "Advanced Ping Detection (MachinaProbeService) started.");
            }
        }

        public void Stop()
        {
            lock (this)
            {
                if (!_isStarted)
                {
                    return;
                }
                _isStarted = false;

                foreach (var context in _processContexts.Values)
                {
                    context.Stop();
                }
                _processContexts.Clear();
                _plugin.Controller.NotifyLogMessageAppend(false, "Advanced Ping Detection (MachinaProbeService) stopped.");
            }
        }

        private void UpdateGameClientVersionTo(FFXIVClientVersion clientVersion)
        {
            if (clientVersion != PacketMonitor.ClientVersion)
            {
                PacketMonitor.ClientVersion = clientVersion;
                _plugin.Controller.NotifyLogMessageAppend(false, $"Game client version = {clientVersion}.");
            }
        }

        private void UpdateGameClientVersion()
        {
            switch (_plugin.Settings.GameClientVersion)
            {
                case SettingsHolder.GameClientVersions.AutoDetection:
                    // Detect game version
                    var version = GameClientInfo.GetLanguage();
                    if (version.IsGlobalGame())
                    {
                        UpdateGameClientVersionTo(FFXIVClientVersion.Global);
                    }
                    else if (version == GameClientInfo.GameLanguage.Cn)
                    {
                        UpdateGameClientVersionTo(FFXIVClientVersion.CN);
                    }
                    else
                    {
                        UpdateGameClientVersionTo(FFXIVClientVersion.Unknown);
                    }

                    break;
                case SettingsHolder.GameClientVersions.Global:
                    UpdateGameClientVersionTo(FFXIVClientVersion.Global);
                    break;
                case SettingsHolder.GameClientVersions.China:
                    UpdateGameClientVersionTo(FFXIVClientVersion.CN);
                    break;
            }
        }

        private class ProcessContext
        {
            public FFXIVNetworkMonitor Monitor { get; } = new FFXIVNetworkMonitor();
            private readonly PacketMonitor _packetMonitor = new PacketMonitor();

            public int CurrentTTL { get; private set; } = -1;

            public long LastEpoch { get; private set; } = 0;

            public ProcessContext(uint pid)
            {
                Monitor.ProcessID = pid;
                Monitor.MonitorType = TCPNetworkMonitor.NetworkMonitorType.RawSocket;
                Monitor.MessageReceived = _packetMonitor.MessageReceived;
                Monitor.MessageSent = _packetMonitor.MessageSent;
                _packetMonitor.OnPingSample += PacketMonitorOnOnPingSample;
            }

            private void PacketMonitorOnOnPingSample(double ttl, DateTime sampleTime)
            {
                CurrentTTL = (int) ttl;
                LastEpoch = sampleTime.EpochMillis();
            }

            public void Start()
            {
                Monitor.Start();
            }

            public void Stop()
            {
                Monitor.Stop();
            }
        }
    }
}
