using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ConvertCharToUnicode
{
    static void Main(string[] args)
    {
        string text = "Hi!";
        for (int i = 0; i <text.Length; i++)
        {
            Console.WriteLine("\\u{0:x4}",(int)text[i]);
        }
    }
}

