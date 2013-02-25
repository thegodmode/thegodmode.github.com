using System;
using System.Linq;

class ConvertToDecimal
{
    static void Main(string[] args)
    {
        string xeh = "0xC3";
        double number = 0;
        for (int i = 2; i < xeh.Length; i++)
        { 
            switch (xeh[i])
            {
                case 'A':
                    number += 10 * Math.Pow(16, xeh.Length - i - 1);
                    break;
                case 'B':
                    number += 11 * Math.Pow(16, xeh.Length - i - 1);
                    break;
                case 'C':
                    number += 12 * Math.Pow(16, xeh.Length - i - 1);
                    break;
                case 'D':
                    number += 13 * Math.Pow(16, xeh.Length - i - 1);
                    break;
                case 'E':
                    number += 14 * Math.Pow(16, xeh.Length - i - 1);
                    break;
                case 'F':
                    number += 15 * Math.Pow(16, xeh.Length - i - 1);
                    break;
                default:
                    number += Double.Parse(xeh[i].ToString()) * Math.Pow(16, xeh.Length - i - 1);
                    break;
            }
        }
        Console.WriteLine(number);
    }
}