using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




public class CheckSubsetIsZero
{
    static int[] numbers = { 3, -2, 1, 1, 8 };
    static int counter = 0;
    static void Main()
    {
        Queue<List<int>> subsetsQueue = new Queue<List<int>>();
        List<int> subset = new List<int>();
        do
        {
            int start = -1;
            if (subset.Count > 0)
            {
                start = subset[subset.Count - 1];
                
            }
            for (int i = start + 1; i < numbers.Length; i++)
            {
                List<int> newSubset = new List<int>();
                newSubset.AddRange(subset);
                newSubset.Add(i);
                subsetsQueue.Enqueue(newSubset);
            }

            subset = subsetsQueue.Dequeue();
            Print(subset);
        } while (subsetsQueue.Count > 0);

        Console.WriteLine(counter);
    }
    static void Print(List<int> subset)
    {
        int sum = 0;
        for (int i = 0; i < subset.Count; i++)
        {
            int index = subset[i];
            sum = sum + numbers[index];
        }
        if (sum == 0)
        {
            counter++;
            Console.Write("[ ");
            for (int i = 0; i < subset.Count; i++)
            {
                int index = subset[i];
                Console.Write("{0} ", numbers[index]);
            }
            Console.WriteLine("]=0");
        }
    }
}



