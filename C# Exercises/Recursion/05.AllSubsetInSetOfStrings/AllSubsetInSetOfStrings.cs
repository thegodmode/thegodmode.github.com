using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class AllSubsetInSetOfStrings
{
    static string[] Set = { "test", "rock", "fun" };

    static void Main(string[] args)
    {
       
        int N = 2;
        string[] subSet = new string[N];
        Loop(0, subSet, Set.Length, 0);

    }

    static void Loop(int index, string[] subSet, int length, int startNumber)
    {

        if (index == subSet.Length)
        {
            Print(subSet);
            return;
        }
        for (int i = startNumber; i < length; i++)
        {
            subSet[index] = Set[i];
            Loop(index + 1, subSet, length, i+1);
        }
    }

    static void Print(string[] array)
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

