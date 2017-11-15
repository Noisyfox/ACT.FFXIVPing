using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ACT.FoxCommon;
using ACT.FoxCommon.core;

namespace ACT.FFXIVPing
{
    class GameProcessMonitor : IPluginComponent
    {
        private readonly MonitorThread _workingThread = new MonitorThread();

        private MainController _controller;

        public void AttachToAct(FFXIVPingPlugin plugin)
        {
            _controller = plugin.Controller;
        }

        public void PostAttachToAct(FFXIVPingPlugin plugin)
        {
            _workingThread.StartWorkingThread(_controller);
        }

        public void Stop()
        {
            _workingThread.StopWorkingThread();
        }

        private class MonitorThread : BaseThreading<MainController>
        {
            protected override void DoWork(MainController context)
            {
                while (!WorkingThreadStopping)
                {
                    var ps = Process.GetProcesses().Select(it =>
                    {
                        try
                        {
                            if (Utils.IsGameExeProcess(it))
                            {
                                return it.Id;
                            }
                        }
                        catch (Exception)
                        {
                        }
                        return -1;
                    }).Where(it => it > 0).Select(it => (uint) it);

                    context.NotifyGameProcessUpdated(false, new HashSet<uint>(ps));

                    SafeSleep(2000);
                }
            }
        }
    }
}
