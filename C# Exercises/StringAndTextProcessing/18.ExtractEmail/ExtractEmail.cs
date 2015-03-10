using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


class ExtractEmail
{
    static void Main(string[] args)
    {
        string email = "Please contact us by phone (+359 222 222 222) or by email at example_me@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";
        int startIndex = -1;
        int EndIndex = 0;
        Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        do
        {
            EndIndex = email.IndexOf(" ", startIndex + 1);
            if (EndIndex > 0)
            {
                string word = email.Substring(startIndex + 1, EndIndex - startIndex - 1);
                if (regex.IsMatch(word))
                {
                    if (word[word.Length - 1] == '.')
                    {
                        Console.WriteLine(word.Substring(0,word.Length-1));
                    }
                    else
                    {
                        Console.WriteLine(word);
                    }


                }
                startIndex = EndIndex;
            }

        } while (EndIndex > 0);

    }
}
