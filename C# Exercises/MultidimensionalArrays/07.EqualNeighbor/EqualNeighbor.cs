using System;
using System.Collections.Generic;
using System.Linq;

class EqualNeighbor
{
    static int[,] matrix = {
        {1,3,2,2,2,4},
        {3,2,3,2,4,4},
        {4,3,1,2,3,3},
        {4,3,1,3,3,1},
        {4,3,3,3,1,1}
    };
    static List<int> path = new List<int>();
    static int counter = 0;
    static int bestCounter = 0;

    static void Main(string[] args)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                GetLength(row, col, matrix[row,col]);
                if (counter > bestCounter)
                {
                    bestCounter = counter;
                }
                
                counter = 0;
            }
        }
        Console.WriteLine(bestCounter);
    }

    static void GetLength(int row, int col, int number)
    {
        if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
        {
            return;
        }
        if (matrix[row,col] == number)
        {
            counter++;
            matrix[row,col] = 0;
            GetLength(row, col + 1, number);
            GetLength(row, col - 1, number);
            GetLength(row + 1, col, number);
            GetLength(row - 1, col, number);
            matrix[row,col] = number;
        }
    }
}