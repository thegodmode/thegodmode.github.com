using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ShowTheSign
{
    static void Main(string[] args)
    {
        int a = 5;
        int b = 7;
        int p = -5;
        if (a>0)
        {
            if (b>0)
            {
                if (p>0)
                {
                    Console.WriteLine("+");
                }
                else
                {
                    Console.WriteLine("-");
                }
            }
            else
            {
                if (p>0)
                {
                    Console.WriteLine("-");
                }
                else
                {
                    Console.WriteLine("+");
                }
            }
        }
        else
        {
            if (b>0)
            {
                if (p>0)
                {
                    Console.WriteLine("-");
                }
                else
                {
                    Console.WriteLine("+");
                }
            }
            else
            {
                if (p > 0)
                {
                    Console.WriteLine("+");
                }
                else
                {
                    Console.WriteLine("-");
                }
            }
        }
                    
    }
}

