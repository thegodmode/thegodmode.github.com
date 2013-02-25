using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CheckIsInCircleOrOutOfTrapezoid
{
    static void Main(string[] args)
    {
        int x = 2;
        int y = 5;
        bool isTrue = true;
        if (((x - 1) * (x - 1) + (y - 1) * (y - 1) > 9) || (x >= -1 && x <= 5 && y <= 1 && y >= -5))
        {
            isTrue = false;
        }

        Console.WriteLine(isTrue);
    }
}

