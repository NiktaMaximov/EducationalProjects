using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.InterlockedExample
{
    public static class InterlockedExample
    {
        public static void InterlockedUsing()
        {
            //В данном случаи возникает состояние гонки, поток стремиться прочитать значение которое еще не было записано
            int counter = 0;
            Parallel.For(1, 100, i =>
            {
                Thread.Sleep(100);
                counter++;
            });

            //В данном случаи используется потокобезопасное увелечение значения
            Parallel.For(1, 100, i =>
            {
                Thread.Sleep(100);
                Interlocked.Increment(ref counter);
            });
        }
    }
}
