using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ReadString
{
    static void Main(string[] args)
    {
        string example = "bojidar";
        if (example.Length<20)
        {
            for (int index = 20-example.Length; index >0; index--)
            {
                example = example.Insert(example.Length,"*");
            }
        }
        Console.WriteLine(example);
    }
}

