using System;
using System.Collections.Generic;
using System.Linq;

class ConvertToHexadecimal
{
    static void Main(string[] args)
    {
        int number = 1415;
        List<object> remainders = new List<object>();
        while (number > 0)
        {
            int remainder = number % 16;
            switch (remainder)
            {
                case 10:
                    remainders.Add('A');
                    break;
                case 11:
                    remainders.Add('B');
                    break;
                case 12:
                    remainders.Add('C');
                    break;
                case 13:
                    remainders.Add('D');
                    break;
                case 14:
                    remainders.Add('E');
                    break;
                case 15:
                    remainders.Add('F');
                    break;
                default:
                    remainders.Add(remainder);
                    break;
            }
            
            number /= 16;
        }
        remainders.Reverse();
        if (remainders.Count > 0)
        {
            foreach (var remainder in remainders)
            {
                Console.Write(remainder);
            }
        }
        else
        {
            Console.Write(0);
        }
       
        Console.WriteLine();
    }
}