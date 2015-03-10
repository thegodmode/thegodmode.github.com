using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class IsBitHasOne
{
    static void Main(string[] args)
    {
        int v = 7;
        int p = 2;
        bool hasOne = false;
        int mask = 1 << p;
        if (((v & mask) >> p) == 1)
        {
            hasOne = true;
            
        }

        Console.WriteLine("v="+v+",p="+p+"->"+hasOne);

    }
}

