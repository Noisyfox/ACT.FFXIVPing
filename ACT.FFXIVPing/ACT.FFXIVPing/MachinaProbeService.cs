﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ACT.FoxCommon;
using ACT.FoxCommon.logging;
using FFXIVPingMachina.PingMonitor;
using LibPingMachina.PingMonitor;
using LibPingMachina.PingMonitor.handler;
using Machina.FFXIV;
using Machina.Infrastructure;

namespace ACT.FFXIVPing
{
    class MachinaProbeService : IPluginComponent
    {
        private FFXIVPingPlugin _plugin;
        private bool _isStarted = false;
        private NetworkMonitorType _currentMonitorType = 0;
        private bool _useDeucalion = false;
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

        private void ControllerOnGameProcessUpdated(bool fromView, HashSet<ProcessInfo> processes)
        {
            lock (this)
            {
                if (!_isStarted)
                {
                    return;
                }

                var oldCtx = new HashSet<uint>(_processContexts.Keys);
                oldCtx.ExceptWith(processes.Select(it => it.Pid));

                foreach (var pid in oldCtx)
                {
                    if (_processContexts.TryRemove(pid, out var ctx))
                    {
                        ctx.Stop();
                    }
                }

                // Check network parse mode
                var targetMonitorType = DetermineMonitorType();
                if (targetMonitorType != _currentMonitorType)
                {
                    _currentMonitorType = targetMonitorType;

                    // Stop all existing monitors since the parse mode has changed
                    foreach (var context in _processContexts.Values)
                    {
                        context.Stop();
                    }
                    _processContexts.Clear();

                    Logger.Info($"Parse mode = {targetMonitorType}.");
                }

                foreach (var process in processes)
                {
                    _processContexts.AddOrUpdate(process.Pid, _pid =>
                    {
                        var ctx = new ProcessContext(process, _currentMonitorType, _useDeucalion);
                        ctx.OnPingOpCodeDetected += code =>
                        {
                            Logger.Info($"IPC Ping OpCode detected for pid={_pid}: {code}");
                        };
                        ctx.Start();
                        return ctx;
                    }, (_, _ctx) => _ctx);
                }
            }
        }

        public void PostAttachToAct(FFXIVPingPlugin plugin)
        {
        }

        public ConnectionPing FindPing(uint pid, out bool processFound)
        {
            processFound = false;
            if (!_isStarted)
            {
                return null;
            }

            if (_processContexts.TryGetValue(pid, out var ctx))
            {
                processFound = true;
                return ctx.CurrentPing;
            }
            return null;
        }

        public KeyValuePair<uint, ConnectionPing>? FirstPing()
        {
            var firstCtx = _processContexts.Values.FirstOrDefault();

            if (firstCtx == null)
            {
                return null;
            }
            else
            {
                return new KeyValuePair<uint, ConnectionPing>(firstCtx.Monitor.ProcessID, firstCtx.CurrentPing);
            }
        }

        private void Start()
        {
            lock (this)
            {
                Stop();
                _isStarted = true;
                Logger.Info("Advanced Ping Detection (MachinaProbeService) started.");
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
                Logger.Info("Advanced Ping Detection (MachinaProbeService) stopped.");
            }
        }

        private NetworkMonitorType DetermineMonitorType()
        {
            switch (_plugin.Settings.ParseMode)
            {
                case SettingsHolder.ParseModes.WinPCap:
                    return NetworkMonitorType.WinPCap;
                case SettingsHolder.ParseModes.Normal:
                default:
                    return NetworkMonitorType.RawSocket;
            }
        }

        private class ProcessContext
        {
            public event IPCPingOpCodeDetector.PingOpCodeDetectDelegate OnPingOpCodeDetected;
            public FFXIVNetworkMonitor Monitor { get; } = new FFXIVNetworkMonitor();
            private readonly PacketMonitor _packetMonitor;
            public ConnectionPing CurrentPing { get; private set; } = null;

            public long LastEpoch { get; private set; } = 0;

            public ProcessContext(ProcessInfo process, NetworkMonitorType monitorType, bool useDeucalion)
            {
                Monitor.ProcessID = process.Pid;
                if (process.FileName == Utils.GameExeNameDx11)
                {
                    Monitor.OodlePath = process.FilePath;
                }
                Monitor.MonitorType = monitorType;
                Monitor.UseDeucalion = useDeucalion;

                // Packet sent by game client won't be captured if filter is enabled for RawSocket mode,
                // so enable the filter only on WinPCap mode.
                Monitor.UseRemoteIpFilter = monitorType == NetworkMonitorType.WinPCap;

                _packetMonitor = new PacketMonitor(useDeucalion);
                Monitor.MessageReceivedEventHandler = _packetMonitor.MessageReceived;
                Monitor.MessageSentEventHandler = _packetMonitor.MessageSent;
                _packetMonitor.OnPingSample += PacketMonitorOnOnPingSample;
                _packetMonitor.OnPingOpCodeDetected += code => OnPingOpCodeDetected?.Invoke(code);
            }

            private void PacketMonitorOnOnPingSample(ConnectionPing ping)
            {
                CurrentPing = ping;
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
