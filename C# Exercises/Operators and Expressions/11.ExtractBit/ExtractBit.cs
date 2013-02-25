using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ExtractBit
{
    static void Main(string[] args)
    {
        int i = 5;
        int b = 2;
        int mask = 1 << b;
        Console.WriteLine("i=" + i + ",b=" + b + "->{0}",(i & mask)>>b);
    }
}

