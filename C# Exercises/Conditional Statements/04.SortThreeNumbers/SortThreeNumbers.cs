using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SortThreeNumbers
{
    static void Main(string[] args)
    {
        int a = 1212;
        int b = 133333;
        int c = 33333;
        if (a > b)
        {
            if (a > c)
            {
                if (b>c)
                {
                    Console.WriteLine("{0},{1},{2}",a,b,c);
                }
                else
                {
                    Console.WriteLine("{0},{1},{2}", a, c, b);
                }
                
            }
            else
            {
                Console.WriteLine("{0},{1},{2}", c,a,b);
            }
        }
        else
        {
            if (b > c)
            {
                if (a>c)
                {
                    Console.WriteLine("{0},{1},{2}", b, a, c);
                }
                else
                {
                    Console.WriteLine("{0},{1},{2}", b, c, a);
                }
                
            }
            else
            {
                Console.WriteLine("{0},{1},{2}",c,b,a);
            }
        }

    }
}

