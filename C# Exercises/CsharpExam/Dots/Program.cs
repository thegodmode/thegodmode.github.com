using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dots
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());
            int dots = N / 2 - 1;
            int slash = 1;
            int backslash = 1;
            for (int i = 0; i < N / 2; i++)
            {
                Console.Write(new string('.', dots - i));
                Console.Write(new string('/', 1));
                if (N - ((dots - i) * 2 + 2) > 0)
                {
                    int inside = N - ((dots - i) * 2 + 2);
                    for (int k = 1; k <= inside / 2; k++)
                    {
                        if (k % 2 == 0)
                        {
                            Console.Write('/');
                        }
                        else
                        {
                            Console.Write(' ');
                        }

                    }

                    for (int k = 1; k <= inside / 2; k++)
                    {
                        if ((inside / 2) % 2 != 0)
                        {
                            if (k % 2 == 0)
                            {
                                Console.Write('\\');
                            }
                            else
                            {
                                Console.Write(' ');
                            }

                        }

                        if ((inside / 2) % 2 == 0)
                        {
                            if (k % 2 == 0)
                            {
                                Console.Write(' ');
                            }
                            else
                            {
                                Console.Write('\\');
                            }

                        }
                    }
                }
                Console.Write(new string('\\', 1));
                Console.Write(new string('.', dots - i));
                Console.WriteLine();
            }
            //---------------------------------------------------------------------
            for (int i = N / 2 - 1; i >= 0; i--)
            {
                Console.Write(new string('.', dots - i));
                Console.Write(new string('\\', 1));
                if (N - ((dots - i) * 2 + 2) > 0)
                {
                    int inside = N - ((dots - i) * 2 + 2);
                    for (int k = 1; k <= inside / 2; k++)
                    {
                        if (k % 2 == 0)
                        {
                            Console.Write('\\');
                        }
                        else
                        {
                            Console.Write(' ');
                        }

                    }

                    for (int k = 1; k <= inside / 2; k++)
                    {
                        if ((inside / 2) % 2 != 0)
                        {
                            if (k % 2 == 0)
                            {
                                Console.Write('/');
                            }
                            else
                            {
                                Console.Write(' ');
                            }

                        }

                        if ((inside / 2) % 2 == 0)
                        {
                            if (k % 2 == 0)
                            {
                                Console.Write(' ');
                            }
                            else
                            {
                                Console.Write('/');
                            }

                        }
                    }
                }
                Console.Write(new string('/', 1));
                Console.Write(new string('.', dots - i));
                Console.WriteLine();
            }

        }
    }
}
