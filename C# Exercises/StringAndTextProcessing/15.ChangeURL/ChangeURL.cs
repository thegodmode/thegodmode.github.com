using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ChangeURL
{
    static void Main(string[] args)
    {
        string fragment = @"<p>Please visit <a href=""http://academy.telerik. com"">our site</a> to choose a training course.Also visit <a href=""www.devbg.org"">our forum</a>to discuss the courses.</p>";
        StringBuilder str = new StringBuilder();
        str.Append(fragment);
        str.Replace("<a href=\"", "[URL=");
        str.Replace("\">", "]");
        str.Replace("</a>", "[/URL]");
        Console.WriteLine(str);
    }


}
