using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GenerateRandomValues
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(rnd.Next(100,201));
        }
    }
}

