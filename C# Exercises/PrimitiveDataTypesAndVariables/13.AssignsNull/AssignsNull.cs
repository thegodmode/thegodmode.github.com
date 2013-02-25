using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class AssignsNull
{
    static void Main(string[] args)
    {
        int ?integer = null;
        double ?db = null;
        Console.WriteLine(integer);
        Console.WriteLine(db);
        integer = integer + 4;
        Console.WriteLine(integer);
    }
}

