using System;
using System.Linq;
using System.Text;

class GenomeDecoder
{
    static void ParseString(string str, int n, int m)
    {
        StringBuilder count = new StringBuilder();
        StringBuilder finalString = new StringBuilder();
        int newLineCounter = 1;
        int charsLineCounter = 0;
        int padding = 0;
        for (int index = 0; index < str.Length; index++)
        {
            if (Char.IsDigit(str[index]))
            {
                count.Append(str[index]);
            }
            else
            {
                if (count.Length == 0)
                {
                    finalString.Append(new string(str[index], 1));
                }
                else
                {
                    finalString.Append(new string(str[index], Int32.Parse(count.ToString())));
                }

                count.Clear();
            }
        }
        padding = CalculatePadding(finalString.Length, n);
        // print
        for (int index = 0; index < finalString.Length;)
        {
            StringBuilder formatingLine = new StringBuilder();
            formatingLine.Append(String.Format("{0} ", newLineCounter++).PadLeft(padding));
            while (true)
            {
                formatingLine.Append(finalString[index++]);
                charsLineCounter++;
                if (index >= finalString.Length)
                {
                    break;
                }
                if (index % n == 0)
                {
                    charsLineCounter = 0;
                    formatingLine.Append('\n');
                    break;
                }
                else if (charsLineCounter % m == 0)
                {
                    formatingLine.Append(' ');
                }
                
            }

            Console.Write(formatingLine);
        }
    }

    static int CalculatePadding(int sum, int m)
    {
        int padding = 1;
        int result = 0;
        result = (int)Math.Ceiling(((double)sum / m));

        while (result > 0)
        {
            result /= 10;
            padding++;
        }

        return padding;
    }

    static void Main()
    {
        string numbers = Console.ReadLine();
        string[] args = ParseNumbers(numbers);
        int n = Int32.Parse(args[0]);
        int m = Int32.Parse(args[1]);
        string mok = Console.ReadLine();
        ParseString(mok, n, m);
    }

    static string[] ParseNumbers(string numbers)
    {
        return numbers.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
    }
}