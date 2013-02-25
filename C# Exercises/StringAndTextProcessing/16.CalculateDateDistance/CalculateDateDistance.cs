using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CalculateDateDistance
{
    static void Main(string[] args)
    {
        Console.Write("Enter the first Date:");
        string date1 = "27.02.2006";
        string date2 = "3.04.2006";
        string[] parseDate1 = ParseDate(date1);
        string[] parseDate2 = ParseDate(date2);
        DateTime dt = new DateTime(2006, 01, 15);
        DateTime dt1 = new DateTime(2006, 03, 30);
        int result = dt1.Day - dt.Day;
        if (result < 0 || dt.Month == 02 || dt1.Month != 02)
        {
            if (dt.Month != 02 && dt1.Month != 02)
            {
                Console.WriteLine(31 - Math.Abs(result));
            }
            else
            {
                Console.WriteLine(28 - Math.Abs(result));
            }

        }
        else
        {
            Console.WriteLine(Math.Abs(result));
        }

    }

    static string[] ParseDate(string date)
    {

        string[] dateArr = new string[3];
        int dateArrIndex = 0;
        int startIndex = 0;
        int endIndex = -1;
        endIndex = date.IndexOf('.', endIndex + 1);
        dateArr[dateArrIndex++] = date.Substring(0, endIndex);
        do
        {
            startIndex = endIndex;
            endIndex = date.IndexOf('.', endIndex + 1);
            if (endIndex > 0)
            {

                dateArr[dateArrIndex++] = date.Substring(startIndex + 1, endIndex - startIndex - 1);
            }
            else
            {
                dateArr[dateArrIndex++] = date.Substring(startIndex + 1);
            }


        } while (endIndex > 0);
        return dateArr;
    }

}
