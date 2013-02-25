using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ChoiceInputs
{
    static void Main(string[] args)
    {   
        Console.WriteLine("Choose youe input!");
        string input = Console.ReadLine();
        Console.WriteLine("Enter variable!");
        switch (input)
        {
            case "double": Console.WriteLine(Double.Parse(Console.ReadLine()) + 1); break;
            case "int": Console.WriteLine(Int32.Parse(Console.ReadLine()) + 1); break;
            case "string": Console.WriteLine(Console.ReadLine() + "*"); break;
            default: Console.WriteLine("Wrong Input use double string or int");
                break;
        }
    }
}

