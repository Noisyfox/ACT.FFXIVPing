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
        private bool _isStarted = false;
        private readonly ConcurrentDictionary<uint, ProcessContext> _processContexts = new ConcurrentDictionary<uint, ProcessContext>();

        public void AttachToAct(FFXIVPingPlugin plugin)
        {
            plugin.Controller.GameProcessUpdated += ControllerOnGameProcessUpdated;
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
                    _processContexts.AddOrUpdate(pid, _pid => new ProcessContext(_pid), (_pid, _ctx) =>
                    {
                        _ctx.Stop();
                        return _ctx;
                    }).Start();
                }
            }
        }

        public void PostAttachToAct(FFXIVPingPlugin plugin)
        {
            Start();
        }

        public int FindTTL(uint pid)
        {
            if (_processContexts.TryGetValue(pid, out var ctx))
            {
                return ctx.CurrentTTL;
            }
            return -1;
        }

        public long FindEpoch(uint pid)
        {
            if (_processContexts.TryGetValue(pid, out var ctx))
            {
                return ctx.LastEpoch;
            }
            return -1;
        }

        private void Start()
        {
            lock (this)
            {
                Stop();
                _isStarted = true;
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
