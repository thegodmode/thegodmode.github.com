using System;
using System.Collections.Generic;
using System.Linq;


class FindMostFrequentNumber
{
    static void Main()
    {
        int[] array =
        {
            4,
            1,
            1,
            4,
            2,
            2,
            2,
            4,
            1,
            2,
            4,
            4,
            4
        };
        List<int> checkedNumbers = new List<int>();
        int freqCounter = 1;
        int maxFreqCounter = Int32.MinValue;
        int number = 0;
        // create logic
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (checkedNumbers.Contains(array[i]))
            {
                continue;
            }
            for (int k = i + 1; k < array.Length; k++)
            {
                if (array[i] == array[k])
                {
                    freqCounter++;
                }
            }
            if (freqCounter > maxFreqCounter)
            {
                maxFreqCounter = freqCounter;
                number = array[i];
            }

            checkedNumbers.Add(array[i]);
            freqCounter = 1;
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
        Console.Write(" } ->");
        Console.Write(" {0},frequence:{1}\n", number, maxFreqCounter);
    }
}