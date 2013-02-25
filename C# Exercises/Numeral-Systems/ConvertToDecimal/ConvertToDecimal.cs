using System;
using System.Linq;

class ConvertToDecimal
{
    static void Main(string[] args)
    {
        string bynaryNumber = "1001";
        double number = 0;
        for (int i = 0; i < bynaryNumber.Length; i++)
        {
            number += Double.Parse(bynaryNumber[i].ToString()) * Math.Pow((double)2, (double)(bynaryNumber.Length - i - 1));
        }
        Console.WriteLine(number);
    }
}