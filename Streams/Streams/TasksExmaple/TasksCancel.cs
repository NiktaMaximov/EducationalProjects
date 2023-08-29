using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.TasksExmaple
{
    public static class TasksCancel
    {
        public static void TasksCancelUsing()
        {
            // Создание метки
            CancellationTokenSource source = new CancellationTokenSource();
            var token = source.Token;

            // Создание задачи с отменой
            Task task = new Task(() => LongRunningSum(token), token);
            task.Start();

            // Ожидание нажатия кнопки для отмены задачи
            Console.ReadLine();
            source.Cancel();
        }

        public static void LongRunningSum(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 1000; i++)
            {
                Task.Delay(100);
                if (cancellationToken.IsCancellationRequested)
                    cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}
