using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.ParallelExample
{
    public static class ParallelInvokeExmaple
    {
        public static void ParallelInvokeUsing()
        {
            try
            {
                Parallel.Invoke(() => Console.WriteLine("Action_1"), new Action(() => Console.WriteLine("Action_2")));
            }
            catch(AggregateException exceptions)
            {
                foreach (var ex in exceptions.InnerExceptions)
                    Console.WriteLine(ex.Message);
            }
        }
    }
}
