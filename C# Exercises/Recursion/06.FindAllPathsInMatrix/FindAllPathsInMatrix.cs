using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class FindAllPathsInMatrix
{
    static char[,] matrix = 
                            {
                                 {' ','x','e','x'},
                                 {' ','x',' ',' '},
                                 {' ',' ',' ','x'},
                                 {'x','x',' ','e'}
                           };
    static char[] path = new char[matrix.GetLength(0) * matrix.GetLength(1)];
    static int pathIndex = 0;
    static int counter = 0;

    static void Main(string[] args)
    {
        FindAllPaths(0, 0, 'S');
        if (counter == 0)
        {
            Console.WriteLine("There are no paths!");
        }
    }

    static void FindAllPaths(int row, int col, char position)
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
            counter++;
        }
        if (matrix[row, col] == ' ')
        {
            matrix[row, col] = 'S';
            FindAllPaths(row, col + 1, 'R');
            FindAllPaths(row, col - 1, 'L');
            FindAllPaths(row + 1, col, 'D');
            FindAllPaths(row - 1, col, 'U');
            matrix[row, col] = ' ';
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


