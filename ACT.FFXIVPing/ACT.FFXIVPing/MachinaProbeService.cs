using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using FFXIVPingMachina.FFXIVNetwork;
using FFXIVPingMachina.PingMonitor;
using Machina;
using Machina.FFXIV;

namespace ACT.FFXIVPing
{
    class MachinaProbeService : IPluginComponent
    {
        private MainController _controller;
        private bool _isStarted = false;
        private readonly ConcurrentDictionary<uint, ProcessContext> _processContexts = new ConcurrentDictionary<uint, ProcessContext>();

        public void AttachToAct(FFXIVPingPlugin plugin)
        {
            _controller = plugin.Controller;
            _controller.GameProcessUpdated += ControllerOnGameProcessUpdated;
            _controller.AdvancedPingEnabled += ControllerOnAdvancedPingEnabled;
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
                _controller.NotifyLogMessageAppend(false, "Advanced Ping Detection (MachinaProbeService) started.");
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
                _controller.NotifyLogMessageAppend(false, "Advanced Ping Detection (MachinaProbeService) stopped.");
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
