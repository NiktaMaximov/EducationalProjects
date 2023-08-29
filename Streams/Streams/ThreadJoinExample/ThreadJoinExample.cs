using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.ThreadJoinExample
{
    public static class ThreadJoinExample
    {
        public static void ThreadJoinUsing()
        {
            int result = 0;
            var childThread = new Thread(() =>
            {
                Thread.Sleep(1000);
                result = 10;
            });

            childThread.Start();
            childThread.Join();

            Console.WriteLine(result);
        }
    }
}
