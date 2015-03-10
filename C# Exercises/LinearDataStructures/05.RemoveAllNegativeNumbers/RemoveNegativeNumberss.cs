using System;
using System.Collections.Generic;
using System.Linq;

class RemoveNegativeNumberss
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        ReadUserNumbers(numbers);

        numbers = RemoveNegativeNumbers(numbers);

        PrintOnConsole(numbers);
    }

    private static List<int> RemoveNegativeNumbers(List<int> numbers)
    {
        if (numbers == null)
        {
            throw new NullReferenceException("Given list can't be null" + numbers);
        }

        List<int> newList = new List<int>();

        foreach (var number in numbers)
        {
            if (number > 0)
            {
                newList.Add(number);
            }
        }

        return newList;
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

    private static void PrintOnConsole(List<int> numbers)
    {
        Console.WriteLine(String.Join(", ", numbers));
    }
}