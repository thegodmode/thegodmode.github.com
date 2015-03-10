using System;
using System.Linq;

class FindSequenceOfMaximalSum
{
    static void Main(string[] args)
    {
        int maxSum = Int32.MinValue;
        int currSum = 0;
        int seqStart = 0;
        int seqEnd = 0;
        int start = 0;
        int[] array =
        {
            2,
            3,
            7,
            -11,
            8,
            8,
            8,
            -6,
            -8,
            -8
        };

        for (int i = 0; i < array.Length; ++i)
        {
            currSum += array[i];
            if (currSum > maxSum)
            {
                maxSum = currSum;
                seqStart = start;
                seqEnd = i;
            }
           
            else if (currSum < 0)
            {
                start = i + 1;
                currSum = 0;
            }
        }

        for (int i = seqStart; i <= seqEnd; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine(maxSum);
    }
}