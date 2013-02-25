using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CheckWordInSentences
{
    static void Main(string[] args)
    {
        string text = "We are living in a yellow submarine. We don't have anything  else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string[] setences = GetSentences(text);
        for (int i = 0; i < setences.Length; i++)
        {
            if (CheckWordInSentence(setences[i], "in"))
            {
                Console.WriteLine(setences[i]);
            }
        }
    }

    static string[] GetSentences(string text)
    {
        string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < sentences.Length; i++)
        {
            sentences[i]=sentences[i].Trim();

        }
        return sentences;
    }

    static bool CheckWordInSentence(string sentence, string word)
    {
        int index = 0;
        index = sentence.IndexOf(word, 0);
        while (index > 0)
        {
            if (sentence.Substring(index - 1, 1) == " " && sentence.Substring(index + word.Length, 1) == " ")
            {
                return true;
            }
            index = sentence.IndexOf(word, index + 1);

        }
        return false;
    }
}

