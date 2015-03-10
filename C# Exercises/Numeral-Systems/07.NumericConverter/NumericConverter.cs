using System;
using System.Collections.Generic;
using System.Linq;

class NumericConverter
{
    static void Main(string[] args)
    {
        string number = "0xD5";
        int s = 16;
        int d = 2;
        int decimalResult = 0;
        List<object> finalResult;
        decimalResult = ConvertToDecimal(number, s);
        finalResult = ConvertToAny(decimalResult, d);
        PrintResult(finalResult);
    }

    static void PrintResult(List<object> result)
    {
        foreach (var item in result)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }

    static List<object> ConvertToAny(int number, int system)
    {
        
        List<object> remainders = new List<object>();
        if (system==10)
        {
            remainders.Add(number);
            return remainders;
        }
        while (number > 0)
        {
            int remainder = number % system;
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

            number /= system;
        }
        if (system==16)
        {
            remainders.Add("0x");
        }
        remainders.Reverse();
        return remainders;
    }

    static int ConvertToDecimal(string number, int system)
    {
        int i = 0;
        double decimalNumber = 0;
        if (system == 10)
        {
            return Int32.Parse(number);
        }
        if (system == 16)
        {
            i += 2;
        }
        while (i < number.Length)
        {
            switch (number[i])
            {
                case 'A':
                    decimalNumber += 10 * Math.Pow(system, number.Length - i - 1);
                    break;
                case 'B':
                    decimalNumber += 11 * Math.Pow(system, number.Length - i - 1);
                    break;
                case 'C':
                    decimalNumber += 12 * Math.Pow(system, number.Length - i - 1);
                    break;
                case 'D':
                    decimalNumber += 13 * Math.Pow(system, number.Length - i - 1);
                    break;
                case 'E':
                    decimalNumber += 14 * Math.Pow(system, number.Length - i - 1);
                    break;
                case 'F':
                    decimalNumber += 15 * Math.Pow(system, number.Length - i - 1);
                    break;
                default:
                    decimalNumber += Double.Parse(number[i].ToString()) * Math.Pow(system, number.Length - i - 1);
                    break;
            }
            i++;
        }
        return (int)decimalNumber;
    }
}