using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class TranslateWordInDictionary
{
    static void Main(string[] args)
    {
        string text =
        @".NET – platform for applications from Microsoft 
        CLR – managed execution environment for .NET 
        namespace – hierarchical organization of classes";
        Dictionary<string, string> newDictionary = CreateDictionary(text);
        Console.WriteLine("Enter word!");
        string word = Console.ReadLine();
        string result = SearchInDictionary(newDictionary, word);
        Console.WriteLine(word + " - " + result);
    }

    static Dictionary<string, string> CreateDictionary(string text)
    {
        int newLineIndex = -1;
        int dashIndex = -1;
        string value = null;
        string key = null;
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        do
        {
            dashIndex = text.IndexOf('–', dashIndex + 1);
            key = text.Substring(newLineIndex + 1, dashIndex - newLineIndex - 1).Trim().ToUpper();
            newLineIndex = text.IndexOf('\n', newLineIndex + 1);
            if (newLineIndex == -1 && dashIndex > 0)
            {
                value = text.Substring(dashIndex + 2);
            }
            else
            {
                value = text.Substring(dashIndex + 2, newLineIndex - dashIndex - 4);
            }
            dictionary.Add(key, value);

        } while (newLineIndex > 0 && dashIndex > 0);

        return dictionary;
    }

    static string SearchInDictionary(Dictionary<string, string> dictionary, string word)
    {
        string value = null;
        if (dictionary.TryGetValue(word.ToUpper(), out value))
        {
            return value;
        }
        else
        {
            return "The word doesnt exist!";
        }
    }
}

