using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.BackgroundWorkerExample
{
    public static class BackgroundWorkerExample
    {
        public static void BackgroundUsingExample()
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;              // Получение отчетов о ходе выполнения
            backgroundWorker.WorkerSupportsCancellation = true;         // Получение отчетов об отмене событий
            backgroundWorker.DoWork += SimulationServiceCall;
            backgroundWorker.ProgressChanged += ProgressChanged;
            backgroundWorker.RunWorkerCompleted += RunWorkerComplete;
            backgroundWorker.RunWorkerAsync();
            Console.WriteLine("для отмены нажмите С");
            while (backgroundWorker.IsBusy)
            {
                if (Console.ReadKey(true).KeyChar == 'C')
                    backgroundWorker.CancelAsync();
            }
        }


        /// <summary>
        /// Метод выполняющийся после завершения фонового потока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void RunWorkerComplete(object sender, RunWorkerCompletedEventArgs args)
        {
            if(args.Error != null)
                Console.WriteLine(args.Error.Message);
            else
                Console.WriteLine($"Result = {args.Result}");
        }

        /// <summary>
        /// Метод отвечающий за прогресс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void ProgressChanged(object sender, ProgressChangedEventArgs args)
        {
            Console.WriteLine($"{args.ProgressPercentage} выполнен");
        }

        /// <summary>
        /// Метод отвечающий за симуляцию работы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void SimulationServiceCall(object sender, DoWorkEventArgs args)
        {
            var worker = sender as BackgroundWorker;
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                if(!worker.CancellationPending)
                {
                    stringBuilder.Append(i);
                    worker.ReportProgress(i);
                    Thread.Sleep(100);
                }
                else
                {
                    worker.CancelAsync();
                }
            }

            args.Result = stringBuilder;
        }
    }
}
