using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SpiralMatrix
{
    static void Main(string[] args)
    {
        int n = Int32.Parse(Console.ReadLine());
        int[,] result = new int[n, n];
        int pos = 1;
        int count = n;
        int value = -n;
        int sum = -1;

        do
        {
            value = -1 * value / n;
            for (int i = 0; i < count; i++)
            {
                sum += value;
                result[sum / n, sum % n] = pos++;
            }
            value *= n;
            count--;
            for (int i = 0; i < count; i++)
            {
                sum += value;
                result[sum / n, sum % n] = pos++;
            }
        } while (count > 0);


        int k = (result.GetLength(0) * result.GetLength(1) - 1).ToString().Length + 1;
        for (int i = 0; i < result.GetLength(0); i++)
     {
         for (int j = 0; j < result.GetLength(1); j++)
         {
             Console.Write(result[i, j].ToString().PadLeft(k, ' '));
         }
         Console.WriteLine();
     }


    }


}

