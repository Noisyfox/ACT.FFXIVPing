using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Machina;
using Machina.FFXIV;

namespace ACT.FFXIVPing
{
    class MachinaProbeService : IPluginComponent
    {
        private static DateTime _dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

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

            public int CurrentTTL { get; private set; } = -1;

            public long LastEpoch { get; private set; } = 0;

//            private long _lastUpdated = 0;
//            private int _updatedTTL = -1;

            public ProcessContext(uint pid)
            {
                Monitor.ProcessID = pid;
                Monitor.MonitorType = TCPNetworkMonitor.NetworkMonitorType.RawSocket;
                Monitor.MessageReceived = MessageReceived;
            }

            private void MessageReceived(long epoch, byte[] message)
            {
                if (epoch > 0)
                {
                    LastEpoch = epoch;
                    var currentTime = (long) (DateTime.Now.ToUniversalTime() - _dt1970).TotalMilliseconds;
                    if (currentTime > epoch)
                    {
                        CurrentTTL = (int) (currentTime - epoch);
                    }
                }
//                else
//                {
//                    
//                }
//                var ttl = currentTime - epoch;
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
