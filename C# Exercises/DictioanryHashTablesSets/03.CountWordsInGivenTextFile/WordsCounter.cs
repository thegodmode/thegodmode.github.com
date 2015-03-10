using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class WordsCounter
{
    static void Main(string[] args)
    {
        string filePath = "file.txt";
        Dictionary<string, int> numberCounter = new Dictionary<string, int>();
        CountWordsInFile(filePath, numberCounter);
        PrintResult(numberCounter);
    }

    private static void CountWordsInFile(string filePath, Dictionary<string, int> numberCounter)
    {
        string line = null;
        using (StreamReader streamReader = new StreamReader(filePath))
        {
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] words = line.Split(new char[] { ' ', '.', '?', '!', ',', '–' }, StringSplitOptions.RemoveEmptyEntries);

                for (int index = 0; index < words.Length; index++)
                {
                    var wordsToLower = words[index].ToLower();
                    if (!numberCounter.ContainsKey(wordsToLower))
                    {
                        numberCounter.Add(wordsToLower, 1);
                    }
                    else
                    {
                        numberCounter[wordsToLower]++;
                    }
                }
            }
        }
    }

    private static void PrintResult(Dictionary<string, int> numberCounter)
    {
        if (numberCounter == null)
        {
            throw new NullReferenceException("numberCounter can't be null");
        }

        foreach (var item in numberCounter)
        {
            Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
        }
    }
}