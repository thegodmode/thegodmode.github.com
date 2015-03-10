using System;
using System.Linq;

class CalculateSumOfStringNumbers
{
    static void Main(string[] args)
    {
        string givenString = "43 68 9 23 318";
        int sum = 0;
        string[] array = givenString.Split(new char[]{' ',}, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < array.Length; i++)
        {
            sum += Int32.Parse(array[i]);
        }

        Console.WriteLine(sum);
    }
}