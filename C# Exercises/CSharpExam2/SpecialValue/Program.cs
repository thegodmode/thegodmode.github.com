using System;

class Program
{
     static int N = Int32.Parse(Console.ReadLine());
     static int[][] matrix = new int[N][];
    static void Main(string[] args)
    {
        int currentValue = 0;
        int maxValue = 0;
              
        for (int i = 0; i < matrix.Length; i++)
        {
           
            string input = Console.ReadLine();
            string[] argss = input.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            matrix[i] = new int[argss.Length];
            for (int j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j] = Int32.Parse(argss[j].Trim());
            }
        }
               
        bool[][] isVisited = new bool[N][];
        Generate(isVisited);
           
        for (int i = 0; i < matrix[0].Length; i++)
        {
            currentValue = StartMoving(matrix, i, isVisited);
            if (currentValue > maxValue)
            {
                maxValue = currentValue;
            }
            GenerateIsVisited(isVisited);
        }

        Console.WriteLine(maxValue);
    }

    private static void Generate(bool[][] isVisited)
    {
        for (int i = 0; i < isVisited.Length; i++)
        {
            isVisited[i] = new bool[matrix[i].Length];
            for (int j = 0; j < isVisited[i].Length; j++)
            {
                isVisited[i][j] = false;
            }
        }
    }

    private static void GenerateIsVisited(bool[][] isVisited)
    {
        for (int i = 0; i < isVisited.Length; i++)
        {
            bool[] temp = isVisited[i];
            for (int j = 0; j < temp.Length; j++)
            {
                temp[j] = false;
            }
        }
    }
  
    private static int StartMoving(int[][] matrix, int startIndex, bool[][]isVisited)
    {
        int index = startIndex;
        int matrixheight = 0;
        int path = 1;
        while (index >= 0)
        {
            if (isVisited[matrixheight][index])
            {
                return Int32.MinValue;
            }
            isVisited[matrixheight][index] = true;
            index = matrix[matrixheight++][index];
           
            if (index < 0)
            {
                break;
            }

            if (matrixheight > matrix.Length - 1)
            {
                matrixheight = 0;
            }
            path++;
        }

        return Math.Abs(index) + path;
    }
}