using System;
using System.Collections.Generic;
using System.Linq;

class CountDoubleNumber
{
    static void Main(string[] args)
    {
        double[] givenArray = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
        Dictionary<double, int> numberCounter = new Dictionary<double, int>();

        CountNumbers(givenArray, numberCounter);

        PrintResult(numberCounter);
    }
  
    private static void CountNumbers(double[] givenArray, Dictionary<double, int> numberCounter)
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

    private static void PrintResult(Dictionary<double, int> numberCounter)
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