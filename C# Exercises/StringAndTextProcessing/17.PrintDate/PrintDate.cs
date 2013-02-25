using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;


class PrintDate
{
    static void Main(string[] args)
    {
        string dateString = "15.12.1991 00:00:00";
        string format = "d.MM.yyyy HH:mm:ss";
        CultureInfo provider = CultureInfo.InvariantCulture;
        DateTime result = DateTime.ParseExact(dateString, format,provider);
        result = result.AddHours(6);
        result = result.AddSeconds(30);
        Console.WriteLine("{0} - {1} ", result.ToString(), result.DayOfWeek);
       
        
    }
}

