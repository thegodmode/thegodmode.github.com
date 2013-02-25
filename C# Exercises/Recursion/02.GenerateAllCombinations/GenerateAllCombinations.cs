using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class GenerateAllCombinations
{
    static void Main(string[] args)
    {
        int K = 3;
        int N = 2;
        int[] array = new int[N];
        Loop(0, array, K, 1);

    }

    static void Loop(int index, int[] array, int length,int startNumber)
    {

        if (index == array.Length)
        {
            Print(array);
            return;
        }
        for (int i = startNumber; i <= length; i++)
        {
            array[index] = i;
            Loop(index + 1, array, length, i);
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

