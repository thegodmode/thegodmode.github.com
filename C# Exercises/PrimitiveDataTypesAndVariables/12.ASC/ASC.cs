using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ASC
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        for (int index = 0; index < 128; index++)
        {
            Console.WriteLine(index+"-"+(char)index);
        }
    }
}

