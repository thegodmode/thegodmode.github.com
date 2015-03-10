using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ReversWordsInSentence
{
    static void Main(string[] args)
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";
        string[] words = sentence.Split(new char[] { ' ','!','.','?'}, StringSplitOptions.RemoveEmptyEntries);
        for (int i = words.Length-1; i >=0; i--)
        {
            Console.Write(words[i]+" ");
        }

        Console.Write(sentence.Substring(sentence.Length-1));
        Console.WriteLine();
    }
}
