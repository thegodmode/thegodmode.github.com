using System;
using System.Linq;

class Variations
{
    static void Main(string[] args)
    {
        int N = 3;
        int K = 2;
        int[] array = new int[K];
        Loop(0, array, N);
    }

    static void Loop(int index, int[] array, int length)
    {
        if (index == array.Length)
        {
            Print(array);
            return;
        }
        for (int i = 1; i <= length; i++)
        {
            array[index] = i;
            Loop(index + 1, array, length);
        }
    }

    static void Print(int[] array)
    {
        Console.Write("( ");
        for (int index = 0; index < array.Length; index++)
        {
            Console.Write(array[index] + " ");
        }
        Console.Write(")");
        Console.WriteLine();
    }
}