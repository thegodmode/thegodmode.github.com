using System;
using System.Linq;

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

    static bool FindPath(int row, int col, char position)
    {
        if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
        {
            return false;
        }
        path[pathIndex++] = position;
        if (matrix[row, col] == 'e')
        {
            Console.WriteLine("Find Path!");
            return true;
        }
        if (matrix[row, col] == ' ')
        {
            matrix[row, col] = 'S';
            if (FindPath(row, col + 1, 'R'))
            {
                return true;
            }
            else if (FindPath(row, col - 1, 'L'))
            {
                return true;
            }
            else if (FindPath(row + 1, col, 'D'))
            {
                return true;
            }
            else if (FindPath(row - 1, col, 'U'))
            {
                return true;
            }
        }
        pathIndex--;
        return false;
    }
}