using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class IsPathExist
{
    static char[,] matrix = new char[100, 100];
                            
    static char[] path = new char[matrix.GetLength(0) * matrix.GetLength(1)];
    static int pathIndex = 0;
    

    static void Main(string[] args)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = ' ';
            }
        }
        matrix[99, 99] = 'e';
        FindPath(0, 0, 'S');
        
    }

    static void FindPath(int row, int col, char position)
    {
        if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
        {
            return;
        }
        path[pathIndex++] = position;
        if (matrix[row, col] == 'e')
        {
            Console.WriteLine("Find Path!");
            Print(pathIndex);
            
        }
        if (matrix[row, col] == ' ')
        {
            matrix[row, col] = 'S';
            FindPath(row, col + 1, 'R');
            FindPath(row, col - 1, 'L');
            FindPath(row + 1, col, 'D');
            FindPath(row - 1, col, 'U');
            
        }

        pathIndex--;
    }

    static void Print(int end)
    {
        for (int index = 1; index < end; index++)
        {
            Console.Write(path[index] + " ");
        }
        Console.WriteLine();
    }
}




