using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class SortingNumbers
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        ReadUserNumbers(numbers);

        List<int> sortedNumbers = Sort(numbers);

        PrintOnConsole(sortedNumbers);
    }

    private static void PrintOnConsole(List<int> sortedNumbers)
    {
        Console.WriteLine(String.Join(", ", sortedNumbers));
    }

    private static List<int> Sort(List<int> numbers)
    {
        if (numbers == null)
        {
            throw new NullReferenceException("Given list can't be null" + numbers);
        }
        
        var sortedNumbers = numbers.OrderBy(a => a).ToList();
        return sortedNumbers;
    }

    private static void ReadUserNumbers(List<int> numbers)
    {
        Console.WriteLine("Enter empty line for end of sequance");
        var number = Console.ReadLine();

        while (!string.IsNullOrEmpty(number))
        {
            numbers.Add(int.Parse(number));
            number = Console.ReadLine();
        }
    }
}