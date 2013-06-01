using System;
using System.Collections.Generic;
using System.Linq;

class LongestSubsequance
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        ReadUserNumbers(numbers);

        List<int> longestSubsequance = FindLongestSubsequance(numbers);

        PrintOnConsole(longestSubsequance);
    }

    private static List<int> FindLongestSubsequance(List<int> numbers)
    {
        if (numbers == null)
        {
            throw new NullReferenceException("Given list can't be null" + numbers);
        }
        
        if (numbers.Count == 0)
        {
            throw new ArgumentException("Given list length can't be zero" + numbers);
        }

        List<int> subsequance = new List<int>();
        int bestLength = 1;
        int startIndex = 0;
        int currentLength = 1;
        
        // Find the best length of equal numbers and startIndex from given list of numbers
        for (int index = 0; index < numbers.Count - 1; index++)
        {
            if (numbers[index] == numbers[index + 1])
            {
                currentLength++;
            }
            else
            {
                if (currentLength > bestLength)
                {
                    startIndex = index - currentLength + 1;
                    bestLength = currentLength;
                }
                currentLength = 1;
            }
        }

        // After the loop is finished check if last subsequance is best 
        if (currentLength > bestLength)
        {
            startIndex = numbers.Count - 1 - currentLength + 1;
            bestLength = currentLength;
        }

        CreateSubsequance(startIndex, bestLength, numbers, subsequance);

        return subsequance;
    }
  
    private static void CreateSubsequance(int startIndex, int bestLength, List<int> numbers, List<int> subsequance)
    {
        for (int index = startIndex; index < bestLength + startIndex; index++)
        {
            subsequance.Add(numbers[index]);
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