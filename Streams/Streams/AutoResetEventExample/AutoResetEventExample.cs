using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.AutoResetEventExample
{
    public static class AutoResetEventExample
    {
        public static void AutoResetEventUsing()
        {
            // false - означает, что все потоки должны ждать сигнала
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);

            Task signalTask = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    autoResetEvent.Set(); // Отправляем сигнал
                }
            });

            int sum = 0;

            Parallel.For(1, 10, (i) =>
            {
                autoResetEvent.WaitOne(); // Ждем сигнал
                sum += i;
            });
        }
    }
}
