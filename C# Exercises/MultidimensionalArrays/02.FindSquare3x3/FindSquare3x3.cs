using System;
using System.Linq;


class FindSquare3x3
{
    static void Main()
    {
        int[,] matrix =
        {
        {
            1,
            3,
            4,
            5,
            6,
            7,
            76
        },
        {
            0,
            0,
            0,
            0,
            0,
            0,
            75
        },
        {
            0,
            0,
            0,
            0,
            0,
            0,
            98
        },
        {
            0,
            0,
            0,
            0,
            0,
            0,
            7
        },
        {
            0,
            0,
            0,
            0,
            0,
            0,
            56
        }
        };
        long sum = 0;
        long bestSum = 0;
        int bestRow = 0;
        int bestCol = 0;
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                      matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                      matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        Console.WriteLine("Best 3x3 matrix is:");
        Console.WriteLine(matrix[bestRow, bestCol] + " " + matrix[bestRow, bestCol + 1] + " " + matrix[bestRow, bestCol + 2]);
        Console.WriteLine(matrix[bestRow + 1, bestCol] + " " + matrix[bestRow + 1, bestCol + 1] + " " + matrix[bestRow + 1, bestCol + 2]);
        Console.WriteLine(matrix[bestRow + 2, bestCol] + " " + matrix[bestRow + 2, bestCol + 1] + " " + matrix[bestRow + 2, bestCol + 2]);
    }
}