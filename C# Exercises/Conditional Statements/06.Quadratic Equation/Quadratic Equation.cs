using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        int a = Int32.Parse(Console.ReadLine());
        int b = Int32.Parse(Console.ReadLine());
        int c = Int32.Parse(Console.ReadLine());
        int D = b * b - 4 * a * c;
        if (D >= 0)
        {
            if (D==0)
            {
                Console.WriteLine("X1=X2={0}", (-b / (2 * a)));
            }
            else
            {
                Console.WriteLine("X1={0}", (-b + Math.Sqrt(D)) / 2 * a);
                Console.WriteLine("X2={0}", (-b - Math.Sqrt(D)) / 2 * a);
            }
            
        }
        else
        {

            Console.WriteLine("There is no real roots");
        }
    }
}

