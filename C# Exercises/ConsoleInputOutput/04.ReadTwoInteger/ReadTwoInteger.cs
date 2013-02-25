using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ReadTwoInteger
{
    static void Main(string[] args)
    {
        int smallNumber = Int32.Parse(Console.ReadLine());
        int bigNumber = Int32.Parse(Console.ReadLine());
        int counter = 0;

        if (smallNumber > bigNumber)
        {
            smallNumber = smallNumber + bigNumber;
            bigNumber = smallNumber - bigNumber;
            smallNumber = smallNumber - bigNumber;
        }
        for (int number = smallNumber; number <= bigNumber; number++)
        {
            if (number % 5 == 0)
            {
                counter = (bigNumber - number) / 5 + 1;
                break;
            }
        }
        Console.WriteLine("p({0},{1}) = {2}", smallNumber, bigNumber, counter);
    }
}

