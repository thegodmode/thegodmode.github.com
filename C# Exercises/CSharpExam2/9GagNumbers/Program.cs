using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        dic.Add("-!", 0);
        dic.Add("**", 1);
        dic.Add("!!!", 2);
        dic.Add("&&", 3);
        dic.Add("&-", 4);
        dic.Add("!-", 5);
        dic.Add("*!!!", 6);
        dic.Add("&*!", 7);
        dic.Add("!!**!-", 8);

        List<int> numbers = new List<int>();
        string input = Console.ReadLine();
        StringBuilder str = new StringBuilder();
        for (int index = 0; index < input.Length; index++)
        {
            str.Append(input[index]);
            if (dic.ContainsKey(str.ToString()))
            {
                numbers.Add(dic[str.ToString()]);
                str.Length = 0;
            }
        }

        decimal magicNumber = 1;
        for (int i = 0; i < numbers.Count-1; i++)
        {
            magicNumber *= 9;
        }
        decimal finalResult = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            finalResult += numbers[i] * magicNumber;
            magicNumber /= 9;
        }

        Console.WriteLine(finalResult);
    }
}