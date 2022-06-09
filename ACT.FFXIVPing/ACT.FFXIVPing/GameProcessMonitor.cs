using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ACT.FoxCommon;
using ACT.FoxCommon.core;
using ACT.FoxCommon.logging;

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
                    var processes = Utils.GetGameProcesses().ToHashSet();
                    Logger.Debug($"Game processes: [{string.Join(",", processes)}]");
                    context.NotifyGameProcessUpdated(false, processes);

                    SafeSleep(2000);
                }
            }
        }
    }
}
