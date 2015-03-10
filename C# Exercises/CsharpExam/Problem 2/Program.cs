using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BigInteger> numbers = new List<BigInteger>();

            for (int i = 0; i < 3; i++)
            {
                numbers.Add(BigInteger.Parse(Console.ReadLine()));
            }
            int line = Int32.Parse(Console.ReadLine());
            int index = 0;
            int numbercounter = 0;
            BigInteger lastNumber = 0;
            for (int i = line; i > 0; i--)
            {
                numbercounter += i;
            }
            for (int i = 0; i < numbercounter - 3; i++)
            {
                numbers.Add(numbers[index] + numbers[index+1] + numbers[index+2]);
                index++;
            }

            index = 0;

            for (int i = 1; i <= line; i++)
            {
                for (int k = i; k > 0; k--)
                {
                    Console.Write(numbers[index++] + " ");
                }
                Console.WriteLine();
            }

        }

    }
}

