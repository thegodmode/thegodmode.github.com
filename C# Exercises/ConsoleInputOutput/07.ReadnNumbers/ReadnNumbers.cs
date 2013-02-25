using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ReadnNumbers
{
    static void Main(string[] args)
    {
        int n = Int32.Parse(Console.ReadLine());
        int sum = 0;
        int number = 0;
        bool isParse = false;
        for (int index = 0; index < n; index++)
        {
            do
            {
                isParse = Int32.TryParse(Console.ReadLine(), out number);

            } while (!isParse);
            sum = sum + number;
        }
        Console.WriteLine(sum);
    }
}

