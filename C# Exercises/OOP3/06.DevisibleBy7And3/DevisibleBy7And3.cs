using System;
using System.Linq;

class DevisibleBy7And3
{
    static void Main(string[] args)
    {
        // Lambda
        int[] arr = {1,3,4,5,6,7,8,9,2131,41,41,5754,23,834,321,21};

        var newArr = arr.Where(a => (a % 3 == 0 && a % 7 == 0));
        foreach (var item in newArr)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("---------------------------------------------------");

        // LINQ
        var linqArr =
        from item in arr
        where item % 3 == 0 && item % 7 == 0
        select item;

        foreach (var item in newArr)
        {
            Console.WriteLine(item);
        }

    }
}