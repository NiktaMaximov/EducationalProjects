using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.TasksExmaple
{
    public static class TasksExample
    {
        public static void TaskUsing()
        {
            // Синтаксис лямбда-выражения
            Task task = new Task(() => PrintNumber());
            task.Start();

            // Делегат Action
            Task taskAction = new Task(new Action(PrintNumber));
            taskAction.Start();

            // Делегат
            Task taskDelegate = new Task(delegate { PrintNumber(); });
            taskDelegate.Start();

            // Создание через TaskFactory
            Task.Factory.StartNew(() => PrintNumber());

            // Создание через Task.Run (подобен StartNew)
            Task.Run(() => PrintNumber());
        }

        public static void PrintNumber()
        {
            Console.WriteLine("Start Method");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"i = {i}");
            }

            Console.WriteLine("Finish Method");
            Console.WriteLine();
        }
    }
}
