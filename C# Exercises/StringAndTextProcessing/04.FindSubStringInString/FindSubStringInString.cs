using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class FindSubStringInString
{
    static void Main(string[] args)
    {
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string substring = "in";
        int counter = 0;
        int index = 0;
        index = text.IndexOf(substring, 0, StringComparison.OrdinalIgnoreCase);
        while (index>0)
        {
            counter++;
            index = text.IndexOf(substring, index+1,StringComparison.OrdinalIgnoreCase);
        }
        Console.WriteLine(counter);
    }
}

