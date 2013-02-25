using System;
using System.Collections.Generic;
using System.Linq;


class HexaDecimalToBinary
{
    static void Main(string[] args)
    {
        string xeh = "0xFFFF";
        List<string> binary = new List<string>();
        for (int i = 2; i < xeh.Length; i++)
        {
            switch (xeh[i])
            {
                case '0':
                    binary.Add("0000");
                    break;
                case '1':
                    binary.Add("0001");
                    break;
                case '2':
                    binary.Add("0010");
                    break;
                case '3':
                    binary.Add("0011");
                    break;
                case '4':
                    binary.Add("0100");
                    break;
                case '5':
                    binary.Add("0101");
                    break;
                case '6':
                    binary.Add("0110");
                    break;
                case '7':
                    binary.Add("0111");
                    break;
                case '8':
                    binary.Add("1000");
                    break;
                case '9':
                    binary.Add("1001");
                    break;
                case 'A':
                    binary.Add("1010");
                    break;
                case 'B':
                    binary.Add("1011");
                    break;
                case 'C':
                    binary.Add("1100");
                    break;
                case 'D':
                    binary.Add("1101");
                    break;
                case 'E':
                    binary.Add("1110");
                    break;
                case 'F':
                    binary.Add("1111");
                    break;
                default:
                    binary.Add("1010");
                    break;
            }
        }

        foreach (var item in binary)
        {
            Console.Write(item);
        }
        Console.WriteLine();

    }
}