using System;
using System.Collections.Generic;
using System.Linq;

class RemoveOddNumberMain
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        ReadUserNumbers(numbers);

        numbers = RemoveOddAccurance(numbers);

        PrintOnConsole(numbers);
    }

    private static List<int> RemoveOddAccurance(List<int> numbers)
    {
        if (numbers == null)
        {
            throw new NullReferenceException("Given list can't be null" + numbers);
        }
        
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        List<int> newListOfNumbers = new List<int>();
        CreateDictionary(numbers, dictionary);

        foreach (var item in numbers)
        {
            if (dictionary[item] % 2 == 0)
            {
                newListOfNumbers.Add(item);
            }
        }

        return newListOfNumbers;
    }
  
    private static void CreateDictionary(List<int> numbers, Dictionary<int, int> dictionary)
    {
        foreach (var number in numbers)
        {
            if (!dictionary.ContainsKey(number))
            {
                dictionary.Add(number, 1);
            }
            else
            {
                dictionary[number]++;
            }
        }
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