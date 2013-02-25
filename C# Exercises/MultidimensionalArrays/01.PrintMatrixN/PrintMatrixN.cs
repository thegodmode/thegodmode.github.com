using System;
using System.Linq;

class PrintMatrixN
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter N");
        int n = Int32.Parse(Console.ReadLine());
        int number = 1;
        int pos = 1;
        int count = n;
        int value = -n;
        int sum = -1;
        int[,] matrix = new int[n, n];
        // Start A
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = number++;
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(Convert.ToString(matrix[row, col]).PadRight(4));
            }
            Console.WriteLine();
        }
        // End A

        // Start B
        Console.WriteLine();
        number = 1;
        for (int col = 0; col < n; col++)
        {
            if (col % 2 != 0)
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = number++;
                }
            }
            else
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = number++;
                }
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(Convert.ToString(matrix[row, col]).PadRight(4));
            }
            Console.WriteLine();
        }
        // Start C
        Console.WriteLine();
        number = 1;
        for (int slice = 2 * n - 1; slice > 0; slice--)
        {
            int z = slice <= n ? 0 : slice - n;
            int k = slice <= n ? n - slice : 0;
            for (int j = z, col = k; j < slice - z; j++, col++)
            {
                matrix[j, col] = number++;
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(Convert.ToString(matrix[row, col]).PadRight(4));
            }
            Console.WriteLine();
        }

        //END C
        Console.WriteLine();
        //Start D
        do
        {
            value = -1 * value / n;
            for (int i = 0; i < count; i++)
            {
                sum += value;
                matrix[sum % n, sum / n] = pos++;
            }
            value *= n;
            count--;
            for (int i = 0; i < count; i++)
            {
                sum += value;
                matrix[sum % n, sum / n] = pos++;
            }
        }
        while (count > 0);

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(Convert.ToString(matrix[row, col]).PadRight(4));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        //End D
    }
}