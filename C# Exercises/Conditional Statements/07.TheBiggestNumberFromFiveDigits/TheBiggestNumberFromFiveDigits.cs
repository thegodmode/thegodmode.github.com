using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class TheBiggestNumberFromFiveDigits
{
    static void Main(string[] args)
    {
        int[] numbers = new int[5] { 2033, 310, 120, 42142142, 6321321 };
        int theBiggest = Int32.MinValue;
        for (int i = 0; i < 5; i++)
        {
            if (numbers[i]>theBiggest)
            {
                theBiggest = numbers[i];
            }
        }
        Console.WriteLine("The Biggest Number is:{0}",theBiggest);
    }

}

