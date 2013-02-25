using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class TheBiggestInteger
{
    static void Main(string[] args)
    {
        int a = 30;
        int b = 233333;
        int c = 1211;
        if (a>b)
        {
            if (a > c)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(c);
            }
        }
        else
        {
            if (b>c)
            {
                Console.WriteLine(b); 
            }
            else
            {
                Console.WriteLine(c);
            }
        }
       
    }
}

