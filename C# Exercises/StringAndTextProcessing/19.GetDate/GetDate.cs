using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


class GetDate
{
    static void Main(string[] args)
    {
        string email = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";
        int startIndex = -1;
        int EndIndex = 0;
        Regex regex = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$");
        do
        {
            EndIndex = email.IndexOf(" ", startIndex + 1);
            if (EndIndex > 0)
            {
                string word = email.Substring(startIndex + 1, EndIndex - startIndex - 1);
                if (word[word.Length - 1] == '.')
                {
                    word = (word.Substring(0, word.Length - 1));
                }
                if (regex.IsMatch(word))
                {
                    Console.WriteLine(word);

                }
                startIndex = EndIndex;
            }

        } while (EndIndex > 0);

    }
}

