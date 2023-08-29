using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.TasksExmaple
{
    public static class TaskChildren
    {
        public static void TaskChildrenUsing()
        {
            // Создание отсоединенной задачи
            Task parentTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Запущена родительская задача");
                Task childTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Запущена дочерняя задача");
                });

                Console.WriteLine("Родительская задача завершила работу");
            });

            parentTask.Wait();
            Console.WriteLine("Работа завершена");

            // Создание присоединенной задачи
            Task parentTask2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Запущена родительская задача");
                Task childTask2 = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Запущена дочерняя задача");
                }, TaskCreationOptions.AttachedToParent);

                Console.WriteLine("Родительская задача завершила работу");
            });

            parentTask2.Wait();
            Console.WriteLine("Работа завершена");
        }
    }
}
