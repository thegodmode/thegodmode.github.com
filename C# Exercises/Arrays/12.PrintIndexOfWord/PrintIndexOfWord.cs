using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class PrintIndexOfWord
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter word:");
        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {
            Console.Write(binarySearch(word[i])+" ");
        }


    }

    static int binarySearch(char value)
    {
        char[] sortedArray = { 'A','B','C','D','E','F','G','H','I','J',
                         'K','L','M','N','O','P','Q','R','S','T',
                         'U','V','W','X','Y','Z',
                         'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 
                         'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 
                         'v', 'w', 'x', 'y', 'z',
                         
                       };
        int start = 0;
        int end = sortedArray.Length - 1;
        int middle = 0;
        while (start <= end)
        {
            middle = start + (end - start) / 2;
            if (value == sortedArray[middle])
            {
                return sortedArray[middle];
            }
            else if (value > sortedArray[middle])
            {
                start = middle + 1;
            }
            else
            {
                end = middle - 1;
            }

        }

        return -1;
    }
}

