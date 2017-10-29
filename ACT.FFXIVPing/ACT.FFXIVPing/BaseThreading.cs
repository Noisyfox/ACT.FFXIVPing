using System;
using System.Threading;

namespace ACT.FFXIVPing
{
    abstract class BaseThreading<T>
    {
        protected readonly object WorkingThreadLock = new object();
        private readonly object _sleepObj = new object();
        protected bool WorkingThreadStopping { get; private set; } = false;
        private Thread _workingThread;

        public void StartWorkingThread(T context)
        {
            lock (WorkingThreadLock)
            {
                StopWorkingThread();

                _workingThread = SetupThread();
                _workingThread.Start(context);
            }
        }

        public void StopWorkingThread()
        {
            lock (WorkingThreadLock)
            {
                while (_workingThread != null && _workingThread.IsAlive)
                {
                    WorkingThreadStopping = true;
                    lock (_sleepObj)
                    {
                        Monitor.Pulse(_sleepObj);
                    }
                    Monitor.Wait(WorkingThreadLock, 100);
                }
                _workingThread = null;
                WorkingThreadStopping = false;
            }
        }

        private void WorkingThreadFunc(object context)
        {
            try
            {
                DoWork((T) context);
            }
            finally
            {
                lock (WorkingThreadLock)
                {
                    _workingThread = null;
                    Monitor.PulseAll(WorkingThreadLock);
                }
            }
        }

        protected abstract void DoWork(T context);

        protected virtual Thread SetupThread()
        {
            var t = new Thread(WorkingThreadFunc);
            t.IsBackground = true;

            return t;
        }

        protected void SafeSleep(TimeSpan timeout)
        {
            lock (_sleepObj)
            {
                Monitor.Wait(_sleepObj, timeout);
            }
        }

        protected void SafeSleep(int millisecondsTimeout)
        {
            SafeSleep(TimeSpan.FromMilliseconds(millisecondsTimeout));
        }
    }
}
