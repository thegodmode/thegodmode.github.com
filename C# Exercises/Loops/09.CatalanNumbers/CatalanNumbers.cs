using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class CatalanNumbers
{
    static void Main(string[] args)
    {
        int N = Int32.Parse(Console.ReadLine());
        BigInteger numerator = 1;
        BigInteger denominator = 1;
        for (BigInteger i = 1; i <= N * 2; i++)
        {
            numerator *= i;
        }
        for (BigInteger i = 1; i <= N + 1; i++)
        {
            if (i <= N)
            {
                denominator *= i * i;
            }
            else
            {
                denominator *= i;
            }

        }

        Console.WriteLine(numerator/denominator);
    }
}

