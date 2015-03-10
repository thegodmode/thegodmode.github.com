using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ReadANumber
{
    static void Main(string[] args)
    {
        int number = 1;
        for (int i = 0; i < 10; i++)
        {
           number = ReadNumber(number);
        }
        
    }

    static int ReadNumber(int start = 1, int end = 100)
    {
        Console.WriteLine("Enter a number!");
        int number = Int32.Parse(Console.ReadLine());
        if (number < start || number > end)
        {
            throw new System.ArgumentOutOfRangeException("The number must be between " + start + " and " + end);
        }
        else
        {
            return number;

        }
    }
}

