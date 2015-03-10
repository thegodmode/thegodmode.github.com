using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class TheGratestCommonDevider
{

    static void Main(string[] args)
    {
        int a = Int32.Parse(Console.ReadLine());
        int b = Int32.Parse(Console.ReadLine());
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        if (a == 0)
            Console.WriteLine(b);
        else
            Console.WriteLine(a);
    }
}

