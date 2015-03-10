using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CheckNumberIsPrime
{
    static void Main(string[] args)
    {
        int number = 73;
        bool isPrime = true;
        if (number == 1)
        {
            isPrime = false;
        }
        else
        {
            for (int index = 2; index <= Math.Sqrt(number); index++)
            {
                if (number % index == 0)
                {
                    isPrime = false;
                    break;
                }
            }

        }
        if (isPrime)
        {
            Console.WriteLine("The number is prime");
        }
        else
        {
            Console.WriteLine("The number is not prime");
        }

    }
}

