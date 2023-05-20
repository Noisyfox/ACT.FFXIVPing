using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ACT.FoxCommon;
using ACT.FoxCommon.core;
using ACT.FoxCommon.logging;
using LibPingMachina.PingMonitor;

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

        private string _textTemplateNormal = "Ping {ping}, {lost}% Pkt Lost";
        private string _textTemplateNoData = "No Ping Data...";

        public void AttachToAct(FFXIVPingPlugin plugin)
        {
            _machinaProbeService = plugin.MachinaService;
            _controller = plugin.Controller;
            _controller.ActivatedProcessPathChanged += ControllerOnActivatedProcessPathChanged;
            _controller.GameProcessUpdated += _workingThread.GameProcessUpdated;
            _controller.RefreshIntervalChanged += ControllerOnRefreshIntervalChanged;
            _controller.OverlayTextTemplateChanged += ControllerOnOverlayTextTemplateChanged;
        }

        public void PostAttachToAct(FFXIVPingPlugin plugin)
        {
        }

        private void ControllerOnRefreshIntervalChanged(bool fromView, double interval)
        {
            _workingThread.StartWorkingThread(new ProbeContext
            {
                Service = this,
                Delay = (int)(interval * 1000)
            });
        }

        private void ControllerOnOverlayTextTemplateChanged(bool fromView, string normal, string noData)
        {
            _textTemplateNormal = PreprocessTemplate(normal);
            _textTemplateNoData = PreprocessTemplate(noData);
            DisplayByPid(_currentPid);
        }

        private static string PreprocessTemplate(string input)
        {
            return input.Replace("\\n", "\n");
        }

        public void Stop()
        {
            _workingThread.StopWorkingThread();
            _contexts.Clear();
        }

        private void ControllerOnActivatedProcessPathChanged(bool fromView, ProcessInfo process)
        {
            _currentPid = process.Pid;
            DisplayByPid(process.Pid);
        }

        private ProcessContext FirstValidPing(DateTime pingWindow)
        {
            return _contexts.Values.FirstOrDefault(c => c.RTT.SampleTime > pingWindow);
        }

        private void DisplayByPid(uint pid, bool tryLast = true)
        {
            // Merge process data from different services
            var machinaPing = _machinaProbeService.FindPing(pid, out var machinaProcessFound);
            var iphlpapiProcessFound = _contexts.TryGetValue(pid, out var iphlpapiContext);

            // Only ping sampled within 1 minute is valid
            var pingWindow = DateTime.UtcNow.AddMinutes(-1);

            var processFound = machinaProcessFound || iphlpapiProcessFound;
            if (!processFound)
            {
                if (tryLast)
                {
                    DisplayByPid(_lastPid, false); 
                    return;
                }

                var firstMachinaContext = _machinaProbeService.FirstValidPing(pingWindow);
                var firstIphlpapiContext = FirstValidPing(pingWindow);

                if (firstMachinaContext.HasValue)
                {
                    pid = firstMachinaContext.Value.Key;
                    machinaPing = firstMachinaContext.Value.Value;
                    processFound = true;

                    if (firstIphlpapiContext != null && firstIphlpapiContext.Pid == pid)
                    {
                        iphlpapiContext = firstIphlpapiContext;
                    }
                }
                else if(firstIphlpapiContext != null)
                {
                    pid = firstIphlpapiContext.Pid;
                    iphlpapiContext = firstIphlpapiContext;
                    processFound = true;
                }
            }

            if (!processFound)
            {
                _controller.NotifyOverlayContentChanged(false, _textTemplateNoData);
            }
            else
            {
                _lastPid = pid;

                var ping = new Dictionary<string, ConnectionPing>
                    {
                        { "Machina", machinaPing },
                        { "iphlpapi", iphlpapiContext?.RTT },
                    }
                    .Where(kv =>
                        kv.Value != null
                        && kv.Value.Ping > 0.5 // Remove zero pings
                        && kv.Value.SampleTime > pingWindow // Remove inactive samples
                    )
                    // Then get the largest ping from all available sources
                    .OrderByDescending(kv => kv.Value.Ping)
                    .Select(kv => new { kv.Key, kv.Value })
                    .FirstOrDefault();

                string rttStr;
                if (ping == null)
                {
                    rttStr = "N/A";
                }
                else
                {
                    rttStr = $"{(uint)ping.Value.Ping}ms";
                }

                uint lost = iphlpapiContext?.Lost ?? 0;
                var finalStr = _textTemplateNormal
                    .Replace("{ping}", $"{(ping == null ? "-1" : ((uint)ping.Value.Ping).ToString())}")
                    .Replace("{ping_ms_na}", rttStr)
                    .Replace("{local_ip}", ping?.Value?.Connection?.LocalIP ?? "N/A")
                    .Replace("{server_ip}", ping?.Value?.Connection?.RemoteIP ?? "N/A")
                    .Replace("{lost}", $"{lost}");

                _controller.NotifyOverlayContentChanged(false, finalStr);
            }
        }

        private void SubmitRecords(List<ConnectionStasticRecord> records, HashSet<uint> gamePids)
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

            // Remove processes that are no longer presented
            var oldCtx = new HashSet<uint>(_contexts.Keys);
            oldCtx.ExceptWith(gamePids);
            foreach (var pid in oldCtx)
            {
                _contexts.TryRemove(pid, out _);
            }

            // Remove inactivated records
            var now = DateTime.Now;
            _contexts.Values.Where(it => now.Subtract(it.LastActivate).TotalMinutes > 1)
                .Select(it => it.Pid).ToList().ForEach(p=>_contexts.TryRemove(p, out _));

            // Pick one record and display
            DisplayByPid(_currentPid);
        }

        private class ConnectionContext: IComparable<ConnectionContext>
        {
            public Win32PInvoke_iphlpapi.MIB_TCPROW_OWNER_PID Connection { get; }
            public ConnectionIdentifier ConnectionID { get; }
            public DateTime LastActivate = DateTime.Now;

            private readonly LinkedList<ConnectionStasticRecord> _stasticRecords =
                new LinkedList<ConnectionStasticRecord>();

            public long RTT;
            public uint Lost;

            public ConnectionContext(Win32PInvoke_iphlpapi.MIB_TCPROW_OWNER_PID connection)
            {
                Connection = connection;
                ConnectionID = new ConnectionIdentifier(Connection.LocalAddress + ":" + Connection.LocalPort + "=>" +
                                                        Connection.RemoteAddress + ":" + Connection.RemotePort);
            }

            public void Update(ConnectionStasticRecord record)
            {
                LastActivate = DateTime.Now;
                var stData = record.StasticData;
                var stPath = record.StasticPath;

                RTT = (long) stPath.SampleRtt;

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

            public bool IsValidRTT()
            {
                return RTT < uint.MaxValue && RTT >= uint.MinValue;
            }

            public int CompareTo(ConnectionContext other)
            {
                return RTT.CompareTo(other.RTT);
            }
        }

        private class ProcessContext
        {
            private readonly ConcurrentDictionary<Win32PInvoke_iphlpapi.MIB_TCPROW_OWNER_PID, ConnectionContext> _allConnections = new ConcurrentDictionary<Win32PInvoke_iphlpapi.MIB_TCPROW_OWNER_PID, ConnectionContext>();
            public DateTime LastActivate = DateTime.Now;

            public uint Pid;

            public ConnectionPing RTT;
            public uint Lost;

            public void Update(List<ConnectionStasticRecord> records)
            {
                var now = DateTime.Now;
                LastActivate = now;

                foreach (var r in records)
                {
                    _allConnections.GetOrAdd(r.TcpRow, c => new ConnectionContext(c)).Update(r);
                }

                // Remove inactivated connections
                _allConnections.Values.Where(it => now.Subtract(it.LastActivate).TotalMinutes > 1)
                    .Select(it => it.Connection).ToList().ForEach(c => _allConnections.TryRemove(c, out var _));

                var validConnections = _allConnections.Values.Where(it => it.IsValidRTT()).ToList();
                if (validConnections.Count == 0)
                {
                    RTT = null;
                }
                else
                {
                    var rttConn = validConnections.Max();
                    RTT = new ConnectionPing
                    {
                        Connection = rttConn.ConnectionID,
                        Ping = rttConn.RTT,
                        SampleTime = rttConn.LastActivate.ToUniversalTime(),
                    };
                    Lost = validConnections.Select(it => it.Lost).Max();
                }
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

            public override string ToString()
            {
                return $"ConnectionStasticRecord(Timestamp={Timestamp}, TcpRow={TcpRow})";
            }
        }

        private class ProbeThread : BaseThreading<ProbeContext>
        {
            private HashSet<uint> _gamePids = new HashSet<uint>();

            public void GameProcessUpdated(bool fromView, HashSet<ProcessInfo> processes)
            {
                _gamePids = processes.Select(it => it.Pid).ToHashSet();
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
                                .Where(it => !it.RemoteAddress.IsLoopback())
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
                                service.SubmitRecords(records, currentPid);
                            }
                            else
                            {
                                service.SubmitRecords(null, currentPid);
                            }
                        }
                        else
                        {
                            service.SubmitRecords(null, currentPid);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to read TCP_ESTATS", ex);
                    }
                    SafeSleep(delay);
                }
            }
        }
    }
}
