using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.ManualResetEventExample
{
    public static class ManualResetEventExample
    {
        public static void ManualResetEventUsing()
        {
            var manualResetEvent = new ManualResetEvent(false);

            Task signalOff = Task.Factory.StartNew(() =>
            {
                while(true)
                {
                    Thread.Sleep(2000);
                    manualResetEvent.Reset();
                }
            });

            Task signalOn = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(2000);
                    manualResetEvent.Set();
                }
            });

            for (int i = 0; i < 3; i++)
            {
                Parallel.For(0, 5, (i) =>
                {
                    manualResetEvent.WaitOne();
                });
                Thread.Sleep(2000);
            }
        }
    }
}
