using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MaximalIncreasingNumberInArray
{
    static void Main(string[] args)
    {
        int[] array =
        {
            1,
            2,
            3,
            6,
            7,
            6,
            7,
            8,
            9,
            11,
            12,
            11
        };
        int bestLen = 1;
        int index = 0;
        int len = 1;
        // create logic
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1])
            {
                len++;
            }
            if (array[i] >= array[i + 1])
            {
                if (len > bestLen)
                {
                    index = i - len + 1;
                    bestLen = len;
                    len = 1;
                }

                len = 1;
            }
            if (i + 1 == array.Length - 1)
            {
                if (len > bestLen)
                {
                    index = i - len + 2;
                    bestLen = len;
                }
            }
        }

        // print answer
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

        for (int i = 0; i < bestLen; i++)
        {
            if (i < bestLen - 1)
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