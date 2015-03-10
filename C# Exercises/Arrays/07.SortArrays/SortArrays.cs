using System;
using System.Linq;


class SortArrays
{
    static void Main(string[] args)
    {
        int[] array =
        {
            10,
            2,
            5,
            3,
            4
        };
        int i = 0;
        int j = 0;
        int min = 0;
        int temp = 0;

        for (i = 0; i < array.Length - 1; i++)
        {
            min = i;

            for (j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min = j;
                }
            }

            temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }

        Console.Write("{ ");
        for (int k = 0; k < array.Length; k++)
        {
            if (k < array.Length - 1)
            {
                Console.Write(array[k] + ", ");
            }
            else
            {
                Console.Write(array[k]);
            }
        }
        Console.Write(" }");
        Console.WriteLine();
    }
}