using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.ConcurrentBagExample
{
    public static class ConcurrentBagExample
    {
        public static void ConcurrentBagUsing()
        {
            var concurrentBag = new ConcurrentBag<int>();
            
            // Добавление элемента
            concurrentBag.Add(10);
            int item;

            // Получение элемента
            concurrentBag.TryTake(out item);
        }
    }
}
