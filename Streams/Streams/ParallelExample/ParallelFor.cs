using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.ParallelExample
{
    public static class ParallelFor
    {
        public static void ParallelForUsing()
        {
            Parallel.For(1, 100, new ParallelOptions { MaxDegreeOfParallelism = 4}, (i) => Console.WriteLine(i));
        }

        public static void ParallelForEachUsing()
        {
            var list = new List<string> { "Val_1", "Val_2" };
            Parallel.ForEach(list, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (val, parallelStop) =>
            {
                if (val == "Val_1")
                    parallelStop.Stop(); // или parallelStop.Break();
                Console.WriteLine(val);
            });
        }
    }
}
