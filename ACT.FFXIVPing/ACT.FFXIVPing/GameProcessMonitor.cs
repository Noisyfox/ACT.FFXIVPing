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
                    var pids = new HashSet<uint>(Utils.GetGamePids());
                    Logger.Debug($"Game pids: [{string.Join(",", pids)}]");
                    context.NotifyGameProcessUpdated(false, pids);

                    SafeSleep(2000);
                }
            }
        }
    }
}
