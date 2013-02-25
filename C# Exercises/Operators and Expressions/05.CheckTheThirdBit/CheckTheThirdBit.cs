using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CheckTheThirdBit
{
    static void Main(string[] args)
    {
        int number = 69;
        int mask = 1 << 3;
        int result = number & mask;
        Console.WriteLine(Convert.ToString(result >> 3, 2));

    }
}

