using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDawn
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];

            CreateMatrix(matrix);
           // Print(matrix);
            FallDownMatrix(matrix);
           // Print(matrix);
            PrintNumbers(matrix);
        }
        static void CreateMatrix(char[,] matrix)
        {

            int mask = 1;

            for (int row = 0; row < 8; row++)
            {
                byte number = byte.Parse(Console.ReadLine());
                for (int col = 7; col >= 0; col--)
                {
                    mask = mask << col;
                    if (((number & mask) >> col) == 1)
                    {
                        matrix[row, col] = '*';
                    }
                    else
                    {
                        matrix[row, col] = '.';
                    }
                    mask = 1;
                }
            }
        }
        static void Print(char[,] matrix)
        {
            Console.WriteLine();
            for (int row = 0; row < 8; row++)
            {
                for (int col = 7; col >= 0; col--)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void FallDownMatrix(char[,] matrix)
        {
            for (int row = 6; row >= 0; row--)
            {
                for (int col = 7; col >= 0; col--)
                {
                    if (matrix[row, col] == '*')
                    {
                        int i = 1;
                        while (row + i < matrix.GetLength(1))
                        {
                            if (matrix[row + i, col] == '.')
                            {
                                i++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (i!=1)
                        {
                            matrix[row + i - 1, col] = '*';
                            matrix[row, col] = '.';
                        }
                        
                    }
                }
            }

        }
        static void PrintNumbers(char[,] matrix)
        {
            StringBuilder str = new StringBuilder();
            for (int row = 0; row < 8; row++)
            {
                for (int col = 7; col >= 0; col--)
                {
                    if (matrix[row, col] == '*')
                    {
                        str.Append("1");
                    }
                    else
                    {
                        str.Append("0");
                    }

                }
                Console.WriteLine(Convert.ToInt32(str.ToString(), 2));
                str.Clear();
            }
        }
    }
}
