using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.FFXIVPing
{
    class MachinaProbeService : IPluginComponent
    {
        public void AttachToAct(FFXIVPingPlugin plugin)
        {
        }

        public void PostAttachToAct(FFXIVPingPlugin plugin)
        {
        }

        public int FindTTL(int pid)
        {
            return -1;
        }

        public void Start()
        {

        }

        public void Stop()
        {

        }
    }
}
