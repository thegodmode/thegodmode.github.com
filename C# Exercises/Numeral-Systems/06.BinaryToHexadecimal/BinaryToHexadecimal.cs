using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string binary = "11110011";
        List<object> xeh = new List<object>();
        int index = 0;
        binary = AddExtraZeros(binary);
        while (index < binary.Length)
        {
            string substring = binary.Substring(index, 4);
                        
            switch (substring)
            {
                case "0000":
                    xeh.Add("0");
                    break;
                case "0001":
                    xeh.Add("1");
                    break;
                case "0010":
                    xeh.Add("2");
                    break;
                case "0011":
                    xeh.Add("3");
                    break;
                case "0100":
                    xeh.Add("4");
                    break;
                case "0101":
                    xeh.Add("5");
                    break;
                case "0110":
                    xeh.Add("6");
                    break;
                case "0111":
                    xeh.Add("7");
                    break;
                case "1000":
                    xeh.Add("8");
                    break;
                case "1001":
                    xeh.Add("9");
                    break;
                case "1010":
                    xeh.Add("A");
                    break;
                case "1011":
                    xeh.Add("B");
                    break;
                case "1100":
                    xeh.Add("C");
                    break;
                case "1101":
                    xeh.Add("D");
                    break;
                case "1110":
                    xeh.Add("E");
                    break;
                case "1111":
                    xeh.Add("F");
                    break;
                default:
                    Console.WriteLine("Error while converting");
                    break;
            }

            index += 4;
        }

        foreach (var item in xeh)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }

    static string AddExtraZeros(string binary)
    {
        StringBuilder str = new StringBuilder();
        if (binary.Length % 4 != 0)
        {
            str.Append(new string('0', 4 - (binary.Length % 4)));
            str.Append(binary);
            return str.ToString();
        }
        else
        {
            return binary;
        }
       
    }
}