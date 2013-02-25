using System;
using System.Linq;


class CompareArrays
{
    static void Main(string[] args)
    {
        int array1Length = 0;
        int array2Length = 0;
        int[] firstArray;
        int[] secondArray;
        bool isEqual = true;
        Console.WriteLine("Enter length for first array");
        array1Length = Int32.Parse(Console.ReadLine()); 
        Console.WriteLine("Enter length for second array");
        array2Length = Int32.Parse(Console.ReadLine()); 
        Console.WriteLine("Enter numbers for first array");
        firstArray = new int[array1Length];
        secondArray = new int[array2Length];
        for (int i = 0; i < firstArray.Length; i++)
        {
            firstArray[i] = Int32.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter numbers for second array");
        for (int i = 0; i < secondArray.Length; i++)
        {
            secondArray[i] = Int32.Parse(Console.ReadLine());
        }
        if (firstArray.Length == secondArray.Length)
        {
            for (int index = 0; index < firstArray.Length; index++)
            {
                if (firstArray[index] != secondArray[index])
                {
                    isEqual = false;
                    break;
                }
            }
        }
        else
        {
            isEqual = false;
        }
        Console.WriteLine("Arrays are equeal-{0}", isEqual);
    }
}