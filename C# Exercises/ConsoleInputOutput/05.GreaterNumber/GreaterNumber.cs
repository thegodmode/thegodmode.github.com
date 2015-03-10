using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class GreaterNumber
{
    static void Main(string[] args)
    {
        int numberOne = Int32.Parse(Console.ReadLine());
        int numberTwo = Int32.Parse(Console.ReadLine());
        Console.WriteLine(numberOne > numberTwo ? numberOne : numberTwo); 
    }
}

