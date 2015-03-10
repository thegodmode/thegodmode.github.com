using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class PrintNumber
{
    static void Main(string[] args)
    {
        int number = 15;
        Console.Write("{0}".PadRight(15),number);
        Console.Write("{0:X}".PadRight(15), number);
        Console.Write("{0:0%}".PadRight(15), number);
        Console.Write("{0:e}".PadRight(15), number);
    }
}

