using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.PLINQExample
{
    public static class PLINQ
    {
        public static void PLINQUsing()
        {
            var range = Enumerable.Range(1, 1000);
            var resultLINQ = range.Where(i => i % 2 == 0).ToList();                 // Обычный запрос
            var resultPLINQ = range.AsParallel().Where(i => i % 2 == 0).ToList();   // Параллельный запрос
            var resultPLINQOrder = range.AsParallel().AsOrdered().Where(i => i % 2 == 0).ToList();   // Параллельный запрос с сохранением порядка выполнения
        }

        public static void ParallelMergeOptionsUsing()
        {
            var range = ParallelEnumerable.Range(1, 1000);
            var notBuffered = range
                .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                .Where(i => i % 2 == 0)
                .Select(x => { Thread.SpinWait(1000); return x; });

            var autoBuffered = range
                .WithMergeOptions(ParallelMergeOptions.AutoBuffered)
                .Where(i => i % 2 == 0)
                .Select(x => { Thread.SpinWait(1000); return x; });

            var fullyBuffered = range
                .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                .Where(i => i % 2 == 0)
                .Select(x => { Thread.SpinWait(1000); return x; });
        }
    }
}
