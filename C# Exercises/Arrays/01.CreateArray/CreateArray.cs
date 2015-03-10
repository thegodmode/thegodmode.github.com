using System;
using System.Linq;

class CreateArray
{
    static void Main(string[] args)
    {
        int[] array = new int[20];
        for (int index = 0; index < array.Length; index++)
        {
            array[index] = index * 5;
        }
        for (int index = 0; index < array.Length; index++)
        {
            Console.Write(array[index] + " ");
        }
        Console.WriteLine();
    }
}