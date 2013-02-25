using System;
using System.Linq;

class BinarySearchInArray
{
    static void Main(string[] args)
    {
        int[] sortedArray =
        {
            2,
            4,
            6,
            7,
            10,
            32,
            15,
            17
        };
        int start = 0;
        int end = sortedArray.Length - 1;
        int middle = 0;
        int value = 32;
        while (start <= end)
        {
            middle = start + (end - start) / 2;
            if (value == sortedArray[middle])
            {
                Console.WriteLine("Value find at index:{0}", middle);
                break;
            }
            else if (value > sortedArray[middle])
            {
                start = middle + 1;
            }
            else
            {
                end = middle - 1;
            }
        }
    }
}