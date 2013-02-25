using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Least_Majority_Multiple
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Int32.Parse(Console.ReadLine());
            }
            Array.Sort(numbers);
            int counter = 0;
            for (int i = numbers[0]; ; i++)
            {
                for (int k = 0; k < numbers.Length; k++)
                {
                    if (i % numbers[k] == 0)
                    {
                        counter++;
                    }
                }
                if (counter>=3)
                {
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    counter = 0;
                }

            }
        }
    }
}
