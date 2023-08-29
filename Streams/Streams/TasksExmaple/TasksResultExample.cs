using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.TasksExmaple
{
    public static class TasksResultExample
    {
        public static void TaskResultUsing()
        {
            Task<int> task = Task.FromResult(Sum(10));
            Console.WriteLine(task.Result);
        }

        public static int Sum(int n)
        {
            int sum = 0;
            for (int i = 0; i < 100; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}
