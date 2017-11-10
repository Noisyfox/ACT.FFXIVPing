using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Machina;

namespace ACT.FFXIVPing
{
    class NetworkProbeService : IPluginComponent
    {
        private MachinaProbeService _machinaProbeService;
        private MainController _controller;

        private readonly ProbeThread _workingThread = new ProbeThread();
        private readonly ConcurrentDictionary<uint, ProcessContext> _contexts = new ConcurrentDictionary<uint, ProcessContext>();
        private uint _currentPid;
        private uint _lastPid;

        public void AttachToAct(FFXIVPingPlugin plugin)
        {
            _machinaProbeService = plugin.MachinaService;
            _controller = plugin.Controller;
            _controller.ActivatedProcessPathChanged += ControllerOnActivatedProcessPathChanged;
            _controller.GameProcessUpdated += _workingThread.GameProcessUpdated;
        }

        public void PostAttachToAct(FFXIVPingPlugin plugin)
        {
            _workingThread.StartWorkingThread(new ProbeContext
            {
                Service = this
            });
        }

        public void Stop()
        {
            _workingThread.StopWorkingThread();
            _contexts.Clear();
        }

        private void ControllerOnActivatedProcessPathChanged(bool fromView, string path, uint pid)
        {
            _currentPid = pid;
            DisplayByPid(pid);
        }

        private void DisplayByPid(uint pid)
        {
            if (_contexts.TryGetValue(pid, out var conrtext))
            {
                DisplayRecord(conrtext, pid);
            }
            else if (_contexts.TryGetValue(_lastPid, out conrtext))
            {
                DisplayRecord(conrtext, _lastPid);
            }
            else
            {
                var first = _contexts.Values.FirstOrDefault();
                if (first != null)
                {
                    DisplayRecord(first, first.Pid);
                }
                else
                {
                    DisplayRecord(null, pid);
                }
            }
        }

        private void SubmitRecords(List<ConnectionStasticRecord> records)
        {
            if (records != null && records.Count > 0)
            {
                var k = records.GroupBy(it => it.TcpRow.ProcessId).ToDictionary(g => g.Key, g => g.ToList());
                foreach (var r in k)
                {
                    _contexts.GetOrAdd(r.Key, pid => new ProcessContext
                    {
                        Pid = pid
                    }).Update(r.Value);
                }
            }

            // Remove inactivated records
            var now = DateTime.Now;
            _contexts.Values.Where(it => now.Subtract(it.LastActivate).TotalMinutes > 1)
                .Select(it => it.Pid).ToList().ForEach(p=>_contexts.TryRemove(p, out var _));

            // Pick one record and display
            DisplayByPid(_currentPid);
        }

        private void DisplayRecord(ProcessContext ctx, uint pid)
        {
            var ttlMachina = _machinaProbeService.FindTTL(pid);
            var epochMachina = _machinaProbeService.FindEpoch(pid);
            uint lost = 0;
            int ttl;

            _controller.NotifyLogMessageAppend(false, $"ttlMachina={ttlMachina}, epoch={Utility.EpochToDateTime(epochMachina).ToLocalTime()}\n");

            if (ctx == null)
            {
                if (ttlMachina == -1)
                {
                    _controller.NotifyOverlayContentChanged(false, "No Ping Data...");
                    return;
                }
                ttl = ttlMachina;
            }
            else
            {
                lost = ctx.Lost;
                ttl = Math.Max(ttlMachina, ctx.TTL);
            }
            _lastPid = pid;

            string ttlStr;
            if (ttl == -1)
            {
                ttlStr = "N/A";
            }
            else
            {
                ttlStr = $"{ttl}ms";
            }

            _controller.NotifyOverlayContentChanged(false, $"Ping {ttlStr}, {lost}% Pkt Lost");
        }

        private class ConnectionContext
        {
            public Win32PInvoke_iphlpapi.MIB_TCPROW_OWNER_PID Connection;
            public DateTime LastActivate = DateTime.Now;

            private readonly LinkedList<ConnectionStasticRecord> _stasticRecords =
                new LinkedList<ConnectionStasticRecord>();

            public int TTL;
            public uint Lost;

            public void Update(ConnectionStasticRecord record)
            {
                LastActivate = DateTime.Now;
                var stData = record.StasticData;
                var stPath = record.StasticPath;

                TTL = (int)stPath.SampleRtt;

                // TODO: Calculate pkt lost
                while ((_stasticRecords.Count > 0
                        && record.Timestamp.Subtract(_stasticRecords.First.Value.Timestamp).Seconds > 20)
                       || _stasticRecords.Count > 5)
                {
                    _stasticRecords.RemoveFirst();
                }

                var lost = _stasticRecords.Select(record.CalculateLost)
                    .DefaultIfEmpty(0)
                    .Max();

                _stasticRecords.AddLast(record);

                Lost = (uint) lost;

//                if (stData.DataSegsOut != 0)
//                {
//                    Lost = (uint) ((stPath.FastRetran + stPath.PktsRetrans) * 100 / stData.DataSegsOut);
//                }
//                Controller.NotifyLogMessageAppend(false,
//                    $"TotalPkt={stData.DataSegsOut},TotalBytes={stData.DataBytesOut},FastRetran={stPath.FastRetran},PktsRetrans={stPath.PktsRetrans},SndDupAckEpisodes={stPath.SndDupAckEpisodes},BytesRetrans={stPath.BytesRetrans}");
            }
        }

        private class ProcessContext
        {
            private readonly ConcurrentDictionary<Win32PInvoke_iphlpapi.MIB_TCPROW_OWNER_PID, ConnectionContext> _allConnections = new ConcurrentDictionary<Win32PInvoke_iphlpapi.MIB_TCPROW_OWNER_PID, ConnectionContext>();
            public DateTime LastActivate = DateTime.Now;

            public uint Pid;

            public int TTL;
            public uint Lost;

            public void Update(List<ConnectionStasticRecord> records)
            {
                var now = DateTime.Now;
                LastActivate = now;

                foreach (var r in records)
                {
                    _allConnections.GetOrAdd(r.TcpRow, c => new ConnectionContext
                    {
                        Connection = c
                    }).Update(r);
                }

                // Remove inactivated connections
                _allConnections.Values.Where(it => now.Subtract(it.LastActivate).TotalMinutes > 1)
                    .Select(it => it.Connection).ToList().ForEach(c => _allConnections.TryRemove(c, out var _));

                TTL = _allConnections.Values.Select(it => it.TTL).Max();
                Lost = _allConnections.Values.Select(it => it.Lost).Max();
            }
        }

        private class ProbeContext
        {
            public NetworkProbeService Service;
            public int Delay = 3000; // 3s
        }

        private class ConnectionStasticRecord
        {
            public DateTime Timestamp;
            public Win32PInvoke_iphlpapi.MIB_TCPROW_OWNER_PID TcpRow;
            public Win32PInvoke_iphlpapi.TCP_ESTATS_DATA_ROD_v0 StasticData;
            public Win32PInvoke_iphlpapi.TCP_ESTATS_PATH_ROD_v0 StasticPath;

            public double CalculateLost(ConnectionStasticRecord start)
            {
                if (Timestamp <= start.Timestamp)
                {
                    return 0;
                }

                if (StasticData.DataBytesOut <= start.StasticData.DataBytesOut)
                {
                    return 0;
                }

                if (StasticPath.BytesRetrans <= start.StasticPath.BytesRetrans)
                {
                    return 0;
                }
                var sendDelta = StasticData.DataBytesOut - start.StasticData.DataBytesOut;
                var retransDelta = StasticPath.BytesRetrans - start.StasticPath.BytesRetrans;

                return (retransDelta * 100.0 / sendDelta).Clamp(0, 100);
            }
        }

        private class ProbeThread : BaseThreading<ProbeContext>
        {
            private HashSet<uint> _gamePids = new HashSet<uint>();

            public void GameProcessUpdated(bool fromView, HashSet<uint> pids)
            {
                _gamePids = pids;
            }

            protected override void DoWork(ProbeContext context)
            {
                var service = context.Service;
                var delay = context.Delay;

                while (!WorkingThreadStopping)
                {
                    try
                    {
                        var currentPid = _gamePids;
                        var connections = currentPid.Count > 0 ? Win32PInvoke_iphlpapi.GetAllTcpConnections() : null;
                        if (connections != null)
                        {
                            var gameConnections = connections
                                .Where(it => currentPid.Contains(it.ProcessId))
                                .GroupBy(it => it.ProcessId).ToDictionary(g => g.Key, g => g.ToList());

                            if (gameConnections.Count > 0)
                            {
                                var records = new List<ConnectionStasticRecord>();
                                foreach (var connection in gameConnections)
                                {
                                    foreach (var row in connection.Value)
                                    {

                                        var stasticData = new Win32PInvoke_iphlpapi.TCP_ESTATS_DATA_ROD_v0();
                                        var stasticPath = new Win32PInvoke_iphlpapi.TCP_ESTATS_PATH_ROD_v0();
                                        if (
                                            Win32PInvoke_iphlpapi.GetPerTcpConnectionEStats_Data(row,
                                                ref stasticData)
                                            && Win32PInvoke_iphlpapi.GetPerTcpConnectionEStats_Path(row,
                                                ref stasticPath)
                                        )
                                        {
                                            var record = new ConnectionStasticRecord
                                            {
                                                Timestamp = DateTime.Now,
                                                TcpRow = row,
                                                StasticData = stasticData,
                                                StasticPath = stasticPath
                                            };
                                            records.Add(record);
                                        }
                                    }
                                }
                                service.SubmitRecords(records);
                            }
                            else
                            {
                                service.SubmitRecords(null);
                            }
                        }
                        else
                        {
                            service.SubmitRecords(null);
                        }
                    }
                    catch (Exception ex)
                    {
                        service._controller?.NotifyLogMessageAppend(false, ex + "\n");
                    }
                    SafeSleep(delay);
                }
            }
        }
    }
}
