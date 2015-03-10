using System;
using System.Linq;

class FindArrayWithMaximalSum
{
    static void Main(string[] args)
    {
        int sum = 0;
        int bestSum = 0;
        int index = 0;
        Console.Write("Enter number 'K='");
        int K = Int32.Parse(Console.ReadLine());
        Console.Write("Enter number 'N='");
        int N = Int32.Parse(Console.ReadLine());
        if (N<K)
        {
            Console.WriteLine("N must be bigger or equal with K");
            return;
        }
        int[] array = new int[N];
        Console.WriteLine("Enter numbers in array");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Int32.Parse(Console.ReadLine());
        }
        for (int i = 0; i <= array.Length - K; i++)
        {
            for (int k = 0; k < K; k++)
            {
                sum = sum + array[i + k];
            }
            if (sum > bestSum)
            {
                bestSum = sum;
                index = i;
            }
            sum = 0;
        }
        Console.Write("{ ");
        for (int i = 0; i < array.Length; i++)
        {
            if (i < array.Length - 1)
            {
                Console.Write(array[i] + ", ");
            }
            else
            {
                Console.Write(array[i]);
            }
        }
        Console.Write(" }->{ ");

        for (int i = 0; i < K; i++)
        {
            if (i < K - 1)
            {
                Console.Write(array[index + i] + ", ");
            }
            else
            {
                Console.Write(array[index + i]);
            }
        }
        Console.Write(" }");
        Console.WriteLine();
    }
}