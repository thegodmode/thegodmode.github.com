using System;
using System.Linq;

class FindSequenceOfGivenSum
{
    static void Main(string[] args)
    {
        int[] array = { 4, 3, 1, 4, 2, 5, 8 };
        int s = 7;
        int seqStart = 0;
        int seqEnd = 0;
        int sum = 0;

        for (int index = 0; index < array.Length; index++)
        {
            for (int k = index; k < array.Length; k++)
            {
                sum += array[k];
                if (sum > s)
                {
                    sum = 0;
                    break;
                }

                if (sum == s)
                {
                    seqStart = index;
                    seqEnd = k;
                    break;
                }
            }
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
        for (int i = seqStart; i <= seqEnd; i++)
        {
            if (i < seqEnd)
            {
                Console.Write(array[i] + ", ");
            }
            else
            {
                Console.Write(array[i]);
            }
        }

        Console.Write(" }");
        Console.WriteLine();
    }
}