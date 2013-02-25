using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ReplaceForbiddenWords
{
    static void Main(string[] args)
    {
        string[] forbiddenWords = { "Microsoft","CLR","PHP" };
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
       
        foreach (var forbiddenWord in forbiddenWords)
        {
           
            text = text.Replace(forbiddenWord, new string('*', forbiddenWord.Length));
           
        }

        Console.WriteLine(text);
    }
}

