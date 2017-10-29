using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.FFXIVPing
{
    class NetworkProbeService : IPluginComponent
    {
        private MainController _controller;

        private readonly ProbeThread _workingThread = new ProbeThread();
        private readonly ConcurrentDictionary<uint, ProcessContext> _contexts = new ConcurrentDictionary<uint, ProcessContext>();
        private uint _currentPid = 0;
        private uint _lastPid = 0;

        public void AttachToAct(FFXIVPingPlugin plugin)
        {
            _controller = plugin.Controller;
            _controller.ActivatedProcessPathChanged += ControllerOnActivatedProcessPathChanged;
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
                DisplayRecord(conrtext);
            }
            else if (_contexts.TryGetValue(_lastPid, out conrtext))
            {
                DisplayRecord(conrtext);
            }
            else
            {
                var first = _contexts.Values.FirstOrDefault();
                if (first != null)
                {
                    DisplayRecord(first);
                }
                else
                {
                    DisplayRecord(null);
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

        private void DisplayRecord(ProcessContext ctx)
        {
            if (ctx == null)
            {
                _controller.NotifyOverlayContentChanged(false, "No Ping Data...");
                return;
            }

            _lastPid = ctx.Pid;
            _controller.NotifyOverlayContentChanged(false, $"Ping {ctx.TTL}ms, {ctx.Lost}% Pkt Lost");
        }

        private class ProcessContext
        {
            public DateTime LastActivate = DateTime.Now;
            public uint Pid;

            public uint TTL;
            public uint Lost;

            public void Update(List<ConnectionStasticRecord> records)
            {
                LastActivate = DateTime.Now;

                TTL = records.Select(it => it.Stastic.SmoothedRtt).Max();

                // TODO: Calculate pkt lost
            }
        }

        private class ProbeContext
        {
            public NetworkProbeService Service;
            public int Delay = 3000; // 3s
        }

        private class ConnectionStasticRecord
        {
            public Win32PInvoke_iphlpapi.MIB_TCPROW_OWNER_PID TcpRow;
            public Win32PInvoke_iphlpapi.TCP_ESTATS_PATH_ROD_v0 Stastic;
        }

        private class ProbeThread : BaseThreading<ProbeContext>
        {
            protected override void DoWork(ProbeContext context)
            {
                var service = context.Service;
                var delay = context.Delay;

                while (!WorkingThreadStopping)
                {
                    try
                    {
                        var connections = Win32PInvoke_iphlpapi.GetAllTcpConnections();
                        if (connections != null)
                        {
                            var gameConnections = connections
                                .Where(
                                    it => it.ProcessId != 0
                                          && it.ProcessId != 4
                                          && it.State == Win32PInvoke_iphlpapi.MIB_TCP_STATE.MIB_TCP_STATE_ESTAB
                                )
                                .Where(
                                    it =>
                                    {
                                        try
                                        {
                                            return Utils.IsGameExeProcess(it.ProcessId);
                                        }
                                        catch (Exception ex)
                                        {
//                                        service._controller?.NotifyLogMessageAppend(false, $"pid={it.ProcessId}:{ex}\n");
                                        }
                                        return false;
                                    })
                                .GroupBy(it => it.ProcessId).ToDictionary(g => g.Key, g => g.ToList());

                            if (gameConnections.Count > 0)
                            {
                                var records = new List<ConnectionStasticRecord>();
//                                service._controller?.NotifyLogMessageAppend(false,
//                                    $"Find {gameConnections.Count} process(es).");
                                foreach (var connection in gameConnections)
                                {
//                                    service._controller?.NotifyLogMessageAppend(false, $"Game pid: {connection.Key}");
//                                    var i = 0;
                                    foreach (var row in connection.Value)
                                    {
//                                        service._controller?.NotifyLogMessageAppend(false,
//                                            $"\tTCP[{i}] Local Addr: {row.LocalAddress}");
//                                        service._controller?.NotifyLogMessageAppend(false,
//                                            $"\tTCP[{i}] Local Port: {row.LocalPort}");
//                                        service._controller?.NotifyLogMessageAppend(false,
//                                            $"\tTCP[{i}] Remote Addr: {row.RemoteAddress}");
//                                        service._controller?.NotifyLogMessageAppend(false,
//                                            $"\tTCP[{i}] Remote Port: {row.RemotePort}");

                                        var stastic = new Win32PInvoke_iphlpapi.TCP_ESTATS_PATH_ROD_v0();
                                        if (Win32PInvoke_iphlpapi.GetPerTcpConnectionEStats(row, ref stastic))
                                        {
                                            var record = new ConnectionStasticRecord
                                            {
                                                TcpRow = row,
                                                Stastic = stastic
                                            };
//                                            service._controller?.NotifyLogMessageAppend(false,
//                                                $"\tTCP[{i}] RTT: min={stastic.MinRtt},max={stastic.MaxRtt},sample={stastic.SampleRtt},smooth={stastic.SmoothedRtt},variance={stastic.RttVar}");
                                            records.Add(record);
                                        }
//                                        else
//                                        {
//                                            service._controller?.NotifyLogMessageAppend(false,
//                                                "\tGetPerTcpConnectionEStats failed");
//                                        }
//
//                                        i++;
                                    }
                                }
                                service.SubmitRecords(records);
                            }
                            else
                            {
                                service.SubmitRecords(null);
                            }
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
