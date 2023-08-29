using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Streams.ThreadPoolExmaple
{
    public static class ThreadPoolExample
    {
        public static void ThradUsingThreadPool()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintNumber));

        }

        public static void PrintNumber(object count)
        {
            Console.WriteLine("Start Method");

            int n = Convert.ToInt32(count);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"i = {i}");
            }

            Console.WriteLine("Finish Method");
            Console.WriteLine();
        }
    }
}
