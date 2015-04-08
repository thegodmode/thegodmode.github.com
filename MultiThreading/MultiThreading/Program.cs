using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(Example);
            task.Start();
            Console.WriteLine("I am here now 4");
            task.Wait();
            Console.ReadLine();
        }

        private static async void Example()
        {
            Console.WriteLine("I am here now 1");

            var task = DoWork();
            Console.WriteLine("I am here now 3");

            var val = await task;
            Console.WriteLine(val);
        }

        private static async Task<int> DoWork()
        {
            int count = 0;

            Console.WriteLine("I am here now 2");
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(100);
            }

            return count;
        }


    }
}
