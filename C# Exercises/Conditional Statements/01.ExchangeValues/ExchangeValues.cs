using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ExchangeValues
{
    static void Main(string[] args)
    {
        int a = 133;
        int b = 21;
        if (a>b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }

        Console.WriteLine("{0},{1}",a,b);
    }
}

