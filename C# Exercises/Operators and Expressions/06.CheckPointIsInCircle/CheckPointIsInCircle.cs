using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CheckPointIsInCircle
{
    static void Main(string[] args)
    {
        int x = 3;
        int y = 3;
        int r = 5;
        if ((x - 0) * (x - 0) + (y - 0) * (y - 0) <= r * r)
        {
            Console.WriteLine("The point is in the circle");
        }
        else
        {
            Console.WriteLine("The point is NOT in the circle");
        }
    }
}

