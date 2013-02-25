using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class InsertBit
{
    static void Main(string[] args)
    {
        int n = 5;
        int p = 7;
        int v = 1;
        int mask = 1 << p;

        if (v == 1)
        {
            Console.WriteLine(n | mask);
        }
        else
        {
            Console.WriteLine(n & ~(mask));
        }
    }
}

