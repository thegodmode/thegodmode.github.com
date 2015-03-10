using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ExtractURL
{
    static void Main(string[] args)
    {
        string example = "http://www.devbg.org/forum/index.php";
        string[] extractions = ExtractingURL(example);
        for (int i = 0; i < extractions.Length; i++)
        {

           Console.WriteLine(extractions[i]);

        }
    }
    static string[] ExtractingURL(string url)
    {
        int startIndex = 0;
        int endIndex = 0;
        string[] separators = { "://", "/" };
        string[] extractions = new string[3];
        startIndex = url.IndexOf(separators[0], startIndex);
        if (startIndex > 0)
        {
            extractions[0] = url.Substring(0, startIndex);
            endIndex = url.IndexOf(separators[1], startIndex + separators[0].Length);
            if (endIndex > 0)
            {
                extractions[1] = url.Substring(startIndex + separators[0].Length, endIndex - startIndex - separators[0].Length);
                extractions[2] = url.Substring(endIndex);
            }
            else
            {
                extractions[1] = url.Substring(startIndex + separators[0].Length);
                extractions[2] = "None";
            }

        }
        else
        {
            extractions[0] = "None";
            startIndex = url.IndexOf(separators[1], startIndex + 1);
            if (startIndex > 0)
            {
                extractions[1] = url.Substring(0, startIndex);
                extractions[2] = url.Substring(startIndex);
            }
            else
            {
                extractions[1] = url;
                extractions[2] = "None";
            }
        }
        return extractions;
    }
}
