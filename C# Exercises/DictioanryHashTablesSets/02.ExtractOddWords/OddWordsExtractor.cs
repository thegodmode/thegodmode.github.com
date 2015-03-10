using System;
using System.Collections.Generic;
using System.Linq;

class OddWordsExtractor
{
    static void Main(string[] args)
    {
        string[] givenArray = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
        Dictionary<string, int> numberCounter = new Dictionary<string, int>();

        CountWords(givenArray, numberCounter);

        PrintOddWords(numberCounter);
    }

    private static void CountWords(string[] givenArray, Dictionary<string, int> numberCounter)
    {
        if (givenArray == null)
        {
            throw new NullReferenceException("givenArray can't be null");
        }

        if (numberCounter == null)
        {
            throw new NullReferenceException("numberCounter can't be null");
        }

        for (int index = 0; index < givenArray.Length; index++)
        {
            if (!numberCounter.ContainsKey(givenArray[index]))
            {
                numberCounter.Add(givenArray[index], 1);
            }
            else
            {
                numberCounter[givenArray[index]]++;
            }
        }
    }

    private static void PrintOddWords(Dictionary<string, int> numberCounter)
    {
        if (numberCounter == null)
        {
            throw new NullReferenceException("numberCounter can't be null");
        }

        Console.Write("{");
        foreach (var item in numberCounter)
        {
            if (item.Value % 2 != 0)
            {
                Console.Write("{0} ", item.Key);
            }
        }
        Console.Write("}");
    }
}