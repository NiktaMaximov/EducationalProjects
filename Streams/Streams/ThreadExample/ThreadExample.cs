using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.Streams
{
    public static class ThreadExample
    {
        public static void ThradUsing()
        {
            Thread thread = new Thread(new ThreadStart(PrintNumber));
            thread.Start();
        }

        public static void PrintNumber()
        {
            Console.WriteLine("Start Method");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"i = {i}");
            }

            Console.WriteLine("Finish Method");
            Console.WriteLine();
        }
    }
}
