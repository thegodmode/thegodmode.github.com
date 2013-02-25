using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ReverseString
{
    static void Main(string[] args)
    {
        string example = "Bojidar";
        char[] newexample = example.Reverse().ToArray();
        Console.WriteLine(newexample);
    }
}

