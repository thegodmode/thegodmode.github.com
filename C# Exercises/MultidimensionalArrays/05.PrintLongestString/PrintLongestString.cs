using System;
using System.Linq;



class PrintLongestString
{
    static void Main(string[] args)
    {
        string[] stringArray = { "bojidar", "boqnov", "penchev", "thegodmode", "panzcer" };
        Array.Sort(stringArray, (a, b) => a.Length.CompareTo(b.Length));
        for (int i = 0; i <stringArray.Length; i++)
        {
            Console.WriteLine( stringArray[i]); 
        }
    }
}

