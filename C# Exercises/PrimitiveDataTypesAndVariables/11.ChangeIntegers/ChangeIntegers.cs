using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ChangeIntegers
{
    static void Main(string[] args)
    {
        int a = 5;
        int b = 10;
        a = a + b;
        b = a - b;
        a = a - b;
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}

