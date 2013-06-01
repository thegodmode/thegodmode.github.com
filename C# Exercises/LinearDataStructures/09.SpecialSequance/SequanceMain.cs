using System;
using System.Collections.Generic;
using System.Linq;

class SequanceMain
{
    static void Main(string[] args)
    {
        Queue<int> queue = new Queue<int>();
        int counter = 50;
        int N = Int32.Parse(Console.ReadLine());
        queue.Enqueue(N);
        while (counter > 0)
        {
            int dequedNumber = queue.Dequeue();
            Console.WriteLine(dequedNumber);
            
            queue.Enqueue(dequedNumber + 1);
            queue.Enqueue(dequedNumber * 2 + 1);
            queue.Enqueue(dequedNumber + 2);

            counter--;
        }
    }
}