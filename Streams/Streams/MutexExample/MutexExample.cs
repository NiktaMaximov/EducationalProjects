using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.MutexExample
{
    public static class MutexExample
    {
        public static void MutexUsing()
        {
            // Создание безымянного mutex(а)
            var mutex = new Mutex();

            // Создание именнованного mutex(а)
            var nameMutex = new Mutex(false, "MyMutex");

            var range = Enumerable.Range(1, 1000);

            range.AsParallel().AsOrdered().ForAll(i =>
            {
                Thread.Sleep(1000);
                mutex.WaitOne();            // Вызов блокировки
                // запись информации в файл
                mutex.ReleaseMutex();       // Вызов разблокировки
                Console.WriteLine(i);
            });
        }

    }
}
