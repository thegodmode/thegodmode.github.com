using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        byte N = Byte.Parse(Console.ReadLine());
        for (int row = 1; row <= N; row++)
        {
            for (int col = row; col <= N-1+row; col++)
            {
                Console.Write("{0,-2} ",col);
            }
            Console.WriteLine();
        }
    }
}

