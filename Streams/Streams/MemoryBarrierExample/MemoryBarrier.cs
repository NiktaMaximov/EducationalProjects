using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.MemoryBarrierExample
{
    public static class MemoryBarrier
    {
        public static void MemoryBarrierUsing()
        {
            int a = 1, b = 2, c = 3;
            b = c;
            Thread.MemoryBarrier(); // или Interlocked.MemoryBarrier();
                                    // использование барьера памяти
                                    // в данном случаи создается полный барьер
            a = 1;
        }
    }
}
