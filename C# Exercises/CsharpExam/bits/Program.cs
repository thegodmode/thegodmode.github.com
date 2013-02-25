using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDawn
{
    class Program
    {
        public enum direction { down, left, up };
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];

            CreateMatrix(matrix);
           // Print(matrix);
            StartDriving(matrix);
            Console.WriteLine();
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
                        matrix[row, col] = '1';
                    }
                    else
                    {
                        matrix[row, col] = '0';
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
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void StartDriving(char[,] matrix)
        {
            string currentDirection = direction.down.ToString();
            int x = 0;
            int y = 0;
            int tempCounter = 0;
            int moveCounter = 0;
            int directionCounter = 0;
            if (matrix[0, 0] == '1')
            {
                Console.WriteLine("No" + " " + 0);
                return;
            }

            if (matrix[0, 1] == '1')
            {
                Console.WriteLine("No" + " " + 0);
                return;
            }
            while (true)
            {
                tempCounter = 0;
                if (currentDirection.CompareTo("down") == 0)
                {
                    while (y < 8)
                    {
                        if (matrix[y, x] != '1')
                        {
                            y++;
                            moveCounter++;
                            tempCounter++;
                        }
                        else
                        {

                            break;
                        }
                    }
                    if (y > 0)
                    {
                        y--;
                    }

                    if (x == 7 && y == 7)
                    {

                        Console.Write("{0} {1}", moveCounter - directionCounter, directionCounter);
                        return;

                    }
                    if (x + 1 <= 7)
                    {


                        if (matrix[y, x + 1] != '1')
                        {
                            currentDirection = direction.left.ToString();
                            directionCounter++;
                        }
                        else
                        {
                            Console.WriteLine("No" + " " + (moveCounter - directionCounter));
                            return;
                        }

                    }
                    else
                    {
                        Console.WriteLine("No" + " " + (moveCounter - directionCounter));
                        return;
                    }

                }
                else if (currentDirection.CompareTo("left") == 0)
                {
                    while (x < 8)
                    {
                        if (matrix[y, x] != '1')
                        {
                            x++;
                            moveCounter++;
                            tempCounter++;
                        }
                        else
                        {
                            if (tempCounter == 1)
                            {
                                Console.WriteLine("No" + " " + (moveCounter - directionCounter));
                                return;
                            }
                            break;
                        }

                    }

                    x--;
                    if (x == 7 && y == 7)
                    {

                        Console.Write("{0} {1}", moveCounter - directionCounter, directionCounter);
                        return;

                    }

                    if ((directionCounter + 1) % 4 == 0)
                    {
                        if (y + 1 <= 7)
                        {

                            if (matrix[y + 1, x] != '1')
                            {
                                currentDirection = direction.down.ToString();
                                directionCounter++;
                            }
                            else
                            {
                                Console.WriteLine("No" + " " + (moveCounter - directionCounter));
                                return;
                            }

                        }
                        else
                        {
                            Console.WriteLine("No" + " " + (moveCounter - directionCounter));
                        }

                    }
                    else
                    {
                        if (y - 1 >= 0)
                        {

                            if (matrix[y - 1, x] != '1')
                            {
                                currentDirection = direction.up.ToString();
                                directionCounter++;
                            }

                            else
                            {
                                Console.WriteLine("No" + " " + (moveCounter - directionCounter));
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No" + " " + (moveCounter - directionCounter));
                            return;
                        }
                    }


                }
                else if (currentDirection.CompareTo("up") == 0)
                {
                    while (y >= 0)
                    {
                        if (matrix[y, x] != '1')
                        {
                            y--;
                            moveCounter++;
                            tempCounter++;
                        }

                        else
                        {
                            if (tempCounter == 1)
                            {
                                Console.WriteLine("No" + " " + (moveCounter - directionCounter));
                                return;
                            }
                            break;
                        }

                    }
                    y++;
                    if (x == 7 && y == 7)
                    {

                        Console.Write("{0} {1}", moveCounter - directionCounter, directionCounter);
                        return;

                    }
                    if (x + 1 <= 7)
                    {


                        if (matrix[y, x + 1] != '1')
                        {
                            currentDirection = direction.left.ToString();
                            directionCounter++;
                        }
                        else
                        {
                            Console.WriteLine("No" + " " + (moveCounter - directionCounter));
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No" + " " + (moveCounter - directionCounter));
                        return;
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