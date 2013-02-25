using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        int length = 2;
        int[] array = new int[length];
        Loop(0, array);

    }

    static void Loop(int n, int[] array)
    {

        if (n == array.Length)
        {

            Print(array);
            return;
        }
        for (int i = 1; i <= array.Length; i++)
        {
            array[n] = i;
            Loop(n + 1, array);
        }
    }

    static void Print(int[] array)
    {
        for (int index = 0; index < array.Length; index++)
        {
            Console.Write(array[index] + " ");
        }
        Console.WriteLine();
    }
}
