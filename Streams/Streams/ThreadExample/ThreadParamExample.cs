using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.Streams
{
    public static class ThreadParamExample
    {
        public static void ThradParamUsing()
        {
            Thread thread = new Thread(new ParameterizedThreadStart(PrintNumber));
            thread.Start(10);
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
