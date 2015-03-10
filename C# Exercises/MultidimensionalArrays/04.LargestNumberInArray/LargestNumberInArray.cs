using System;
using System.Linq;


class LargestNumberInArray
{
    static void Main(string[] args)
    {
        int K = 141;
        int[] myArray =
        {
            3,
            4,
            12,
            14,
            15,
            16,
            45,
            23,
            145,
            2,
            7,
            23,
            3,
            34,
            2
        };
        int index = 0;
        int i = -1;
        Array.Sort(myArray);
        for (int k = 0; k < myArray.Length; k++)
        {
            Console.Write(myArray[k] + " "); 
        }
        Console.WriteLine();
        do
        {
            i++;
            index = Array.BinarySearch(myArray, K - i);
        }
        while (index < 0);

        if (index != 0)
        {
            Console.WriteLine(myArray[index]);
        }
    }
}