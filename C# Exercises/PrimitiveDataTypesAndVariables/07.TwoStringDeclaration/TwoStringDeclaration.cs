using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class TwoStringDeclaration
{
    static void Main(string[] args)
    {
        string hello = "Hello";
        string world = "World!";
        object helloWorld = hello + " " + world;
        string finalString = (string) helloWorld;
        Console.WriteLine(finalString);
    }
}

