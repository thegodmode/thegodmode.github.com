using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CheckTheThirdDigit
{
    static void Main(string[] args)
    {
        int number = 1799;
        int temp = number;
        for (int index = 0; index < 2; index++)
        {
            temp = temp / 10;
        }

        if (temp % 10 == 7)
        {
            Console.WriteLine(number + "->True");
        }
        else
        {
            Console.WriteLine(number+"->False");
        }
    }
}

