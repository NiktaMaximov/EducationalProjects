using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.LockExample
{
    public static class LockExample
    {
        public static void LockUsing()
        {
            var range = Enumerable.Range(1, 1000);

            for (int i = 0; i < range.Count(); i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            }

            // Паралелльное выполнение
            // При записи информации в файл, была бы ошибка
            range.AsParallel().AsOrdered().ForAll(i =>
            {
                // запись информации в файл
                Console.WriteLine(i);
            });


            // Использование lock
            var obj = new Object(); // Необходимо создать перемнную статического типа
            range.AsParallel().AsOrdered().ForAll(i =>
            {
                Thread.Sleep(1000); // Избегание dump lock в конструкции Lock
                lock(obj)
                {
                    // запись информации в файл
                    Console.WriteLine(i);
                }                
            });
        }
    }
}
