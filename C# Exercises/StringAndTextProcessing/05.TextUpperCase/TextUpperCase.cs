using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class TextUpperCase
{
    static void Main(string[] args)
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.This is the <upcase> first time </upcase> when we are in trouble!";
        text = ToUpperInTags("<upcase>", "</upcase>", text);
        Console.WriteLine(text);

    }

    static String ToUpperInTags(string openTag, string closeTag, string text)
    {
        if (openTag==closeTag)
        {
            throw new System.ArgumentException("Open tag and close tag it can't be the same!", "openTag,closeTag");
        }
        int startUpcaseIndex = 0;
        int endUpcaseIndex = 0;
        startUpcaseIndex = text.IndexOf(openTag, startUpcaseIndex);
        endUpcaseIndex = text.IndexOf(closeTag, startUpcaseIndex);
        while (startUpcaseIndex > 0 && endUpcaseIndex > 0)
        {
            string upperText = text.Substring(startUpcaseIndex + 8, endUpcaseIndex - startUpcaseIndex - 8).ToUpper();
            text = text.Remove(startUpcaseIndex, endUpcaseIndex - startUpcaseIndex + 9);
            text = text.Insert(startUpcaseIndex, upperText);
            startUpcaseIndex = text.IndexOf(openTag, startUpcaseIndex + 1);
            if (startUpcaseIndex > 0)
            {
                endUpcaseIndex = text.IndexOf(closeTag, startUpcaseIndex);
            }

        }
       
        return text;
    }
}

