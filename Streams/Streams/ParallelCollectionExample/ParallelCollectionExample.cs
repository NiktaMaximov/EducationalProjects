using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.ParallelCollectionExample
{
    public static class ParallelCollectionExample
    {
        public static void ParallelCollectionUsing()
        {
            // Создаем очередь и заполняем ее данными
            var queue = new Queue<int>();
            for (int i = 0; i < 500; i++)
            {
                queue.Enqueue(i);
            }

            int sum = 0;

            // Цикл для считывания элементов из очереди и потокобезопасного добавления суммы в перемнную sum
            Parallel.For(0, 500, (i) =>
            {
                int localSum = 0;
                int localValue;

                while(queue.TryDequeue(out localValue))
                {
                    Thread.Sleep(1000);
                    localSum += localValue;
                }
                Interlocked.Add(ref sum, localSum);
            });
        }

        public static void ProducerConsumerUsingConcurrentQueues()
        {
            // Создание параллельной очереди
            var cq = new ConcurrentQueue<int>();
            for (int i = 0; i < 500; i++)
            {
                cq.Enqueue(i);
            }

            int sum = 0;

            // Цикл для считывания элементов из очереди и потокобезопасного добавления суммы в перемнную sum
            Parallel.For(0, 500, (i) =>
            {
                int localSum = 0;
                int localValue;

                while (cq.TryDequeue(out localValue))
                {
                    Thread.Sleep(1000);
                    localSum += localValue;
                }
                Interlocked.Add(ref sum, localSum);
            });
        }
    }
}
