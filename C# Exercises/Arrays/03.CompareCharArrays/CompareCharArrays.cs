using System;
using System.Linq;

class CompareCharArrays
{
    static void Main(string[] args)
    {
        char[] firstArray =
        {
            'e',
            'g',
            'c',
            'd'
        };
        char[] secondArray =
        {
            'e',
            'b',
            'c',
            'd'
        };

        for (int index = 0; index < firstArray.Length; index++)
        {
            if (firstArray[index] > secondArray[index])
            {
                Console.WriteLine("Second array is bigger");
                return;
            }
            if (firstArray[index] < secondArray[index])
            {
                Console.WriteLine("First array is bigger");
                return;
            }
        }
        Console.WriteLine("The arrays are equal");
    }
}