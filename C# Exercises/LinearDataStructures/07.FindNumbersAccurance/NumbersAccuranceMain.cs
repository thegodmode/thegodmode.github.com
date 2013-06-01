using System;
using System.Collections.Generic;
using System.Linq;

class NumbersAccuranceMain
{
    static void Main(string[] args)
    {
        Dictionary<int, int> numbers = new Dictionary<int, int>();

        ReadUserNumbers(numbers);

        PrintOnConsole(numbers);
    }

    private static void ReadUserNumbers(Dictionary<int, int> numbers)
    {
        if (numbers == null)
        {
            throw new NullReferenceException("numbers can't be null");
        }
        
        Console.WriteLine("Enter empty line for end of sequance");
        var number = Console.ReadLine();

        while (!string.IsNullOrEmpty(number))
        {
            int parseNumber = int.Parse(number);
            if (!numbers.ContainsKey(parseNumber))
            {
                numbers.Add(parseNumber, 1);
            }
            else
            {
                numbers[parseNumber]++;
            }
            number = Console.ReadLine();
        }
    }

    private static void PrintOnConsole(Dictionary<int, int> numbers)
    {
        string format = "{0} -> {1} times";
        foreach (var item in numbers)
        {
            Console.WriteLine(format, item.Key, item.Value);
        }
    }
}