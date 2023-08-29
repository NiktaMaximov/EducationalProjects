using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.ConcurrentStackExample
{
    public static class ConcurrentStackExample
    {
        public static void ConcurrentStackUsing()
        {
            // Создание параллельного стека
            var concurrentStack = new ConcurrentStack<int>();

            // Добавление элементов в стек
            concurrentStack.Push(1);
            concurrentStack.PushRange(new[] { 1, 2, 3, 4 });

            int sum = 0;

            Parallel.For(0, 100, (i) =>
            {
                int localSum = 0;
                int localValue;

                while(concurrentStack.TryPop(out localValue))
                {
                    localSum += localValue;
                }
                Interlocked.Add(ref sum, localSum);
            });

            // Получение элементов из стека
            int localValue;
            concurrentStack.TryPop(out localValue);
            concurrentStack.TryPopRange(new[] { 1, 2, 3, 4 });
        }
    }
}
