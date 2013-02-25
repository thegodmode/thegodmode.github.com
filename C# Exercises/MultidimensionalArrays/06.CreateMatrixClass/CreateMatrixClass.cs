using System;
using System.Collections.Generic;
using System.Linq;

class CreateMatrixClass
{
    static void Main(string[] args)
    {
        int[,] array = {
            {3,4,5,6},
            {7,8,9,10}
        };
        int[,] array1 = {
            {3,4,5,6},
            {7,8,9,10},
            {10,11,12,13}
        };

        Matrix m1 = new Matrix(array);
        m1.AddMatrix(array1);
        m1.PrintMatrix();
    }
}

class Matrix
{
    public List<int[,]> matrixList = new List<int[,]>();

    public Matrix(int[,] array)
    {
        matrixList.Add(array);
    }

    public void PrintMatrix()
    {
        foreach (var matrix in matrixList)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(Convert.ToString(matrix[row,col]).PadRight(4));
                }
                Console.WriteLine();
            }
        }
    }

    public void AddMatrix(int[,] array)
    {
        matrixList.Add(array);
    }
}