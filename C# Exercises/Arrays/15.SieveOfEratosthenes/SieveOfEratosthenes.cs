using System;
using System.Collections.Generic;
using System.Linq;


class SieveOfEratosthenes
{
    private static List<long> primes = new List<long>();

    static void Main(string[] args)
    {
        primes.Add(2);
        for (long checkValue = 3; checkValue <= 10000000; checkValue += 2)
        {
            if (IsPrime(checkValue))
            {
                primes.Add(checkValue);
            }
        }

        Console.WriteLine("Finish!");
        foreach (var prime in primes)
        {
            Console.Write(prime + " ");
        }
    }

    static bool IsPrime(long checkValue)
    {
        bool isPrime = true;

        foreach (long prime in primes)
        {
            if (prime <= Math.Sqrt(checkValue))
            {
                if ((checkValue % prime) == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            else
            {
                break;
            }
        }

        return isPrime;
    }
}