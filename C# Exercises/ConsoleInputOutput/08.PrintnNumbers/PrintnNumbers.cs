using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class PrintnNumbers
{
    static void Main(string[] args)
    {
        int n = Int32.Parse(Console.ReadLine());
        for (int index = 1; index <= n; index++)
        {
            Console.WriteLine(index);
        }
    }
}

