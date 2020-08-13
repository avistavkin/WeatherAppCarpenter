using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WeatherApp.Data
{
    public class Threads
    {

        public static Thread StopThread(Thread thread)
        {
            thread.Abort();
            return thread;
        }

        public static Thread StartThread(Thread thread)
        {
            thread.Start();
            return thread;
        }

        public static Thread StartThreadWithJoin(Thread thread)
        {
            thread.Start();
            thread.Join();
            return thread;
        }

        public static Thread ThreadWait(Thread thread,int miliseconds)
        {
            Thread.Sleep(miliseconds);
            return thread;
        }
    }
}
