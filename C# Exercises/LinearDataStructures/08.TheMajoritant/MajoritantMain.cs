using System;
using System.Collections.Generic;
using System.Linq;

class MajoritantMain
{
    static void Main(string[] args)
    {
        Dictionary<int, int> numbers = new Dictionary<int, int>();

        ReadUserNumbers(numbers);

        int number = FindMajoritant(numbers);

        Console.WriteLine(number);
    }

    private static int FindMajoritant(Dictionary<int, int> numbers)
    {
        int majoritantRequareLength = GetMajoritantRequareLength(numbers);
        int candidate = int.MinValue;
        foreach (var item in numbers)
        {
            if (item.Value >= majoritantRequareLength)
            {
                candidate = item.Key;
            }
        }
        return candidate;
    }
  
    private static int GetMajoritantRequareLength(Dictionary<int, int> numbers)
    {
        int majoritantRequareLength = 0;
        foreach (var item in numbers)
        {
            majoritantRequareLength += item.Value;
        }
        majoritantRequareLength = majoritantRequareLength / 2 + 1;
        return majoritantRequareLength;
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
}