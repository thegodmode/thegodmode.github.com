using System;
using System.Linq;



class Program
{
    static string[,] matrix ={ 
                                {"ha","fifi","xx","xx","tt","dsa","dsa"},
                                {"fo","ha","xx","xx","bb","bb","bb"},
                                {"xxx","fifi","ha","zz","zz","dd","bb"}
                              };

    static int[] counter = { 1, 1, 1 };
    static int bestCounter = 1;
    static string bestElement = null;

    static void Main(string[] args)
    {

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                string element = matrix[row, col];
                RightDirection(element, row, col);
                BottomDirection(element, row, col);
                DiagonalDirection(element, row, col);
               
                if ( counter.Max() >= bestCounter)
                {
                    bestCounter = counter.Max();
                    bestElement = element;

                }
                for (int index = 0; index <counter.Length; index++)
                {
                    counter[index] = 1;
                }
            }
        }

        Console.WriteLine("Best element is:{0}->{1}", bestElement, bestCounter);
    }

    static void BottomDirection(string element, int row, int col)
    {

        if (row < matrix.GetLength(0) - 1)
        {
            if (element == matrix[row + 1, col])
            {
                BottomDirection(element, row + 1, col);
                counter[2]++;
            }
        }

    }

    static void RightDirection(string element, int row, int col)
    {

        if (col < matrix.GetLength(1) - 1)
        {
            if (element == matrix[row, col + 1])
            {

                RightDirection(element, row, col + 1);
                counter[0]++;
            }
        }
        
    }
    static void DiagonalDirection(string element, int row, int col)
    {

        if (row < matrix.GetLength(0) - 1 && col < matrix.GetLength(1) - 1)
        {
            if (element == matrix[row + 1, col + 1])
            {
                DiagonalDirection(element, row + 1, col + 1);
                counter[1]++;
            }
        }
    }
}

