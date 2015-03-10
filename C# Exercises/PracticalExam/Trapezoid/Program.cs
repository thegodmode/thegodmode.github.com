using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());
            for (int row = 0; row < N + 1; row++)
            {
                for (int col = 0; col < 2 * N; col++)
                {
                    if (row == 0 && col > N - 1)
                    {
                        Console.Write("*");
                        continue;
                    }
                    else if (N-row==col)
                    {
                        Console.Write("*");
                        continue;
                    }
                    else if (col+1==2*N)
                    {
                        Console.Write("*");
                        continue;
                    }
                    else if (row + 1 == N + 1)
                    {
                        Console.Write("*");
                        continue;
                    }
                    Console.Write(".");
                }
                Console.WriteLine();
            }
        }
    }
}
