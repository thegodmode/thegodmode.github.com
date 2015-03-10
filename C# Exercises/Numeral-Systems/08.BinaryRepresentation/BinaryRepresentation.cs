using System;
using System.Linq;
using System.Text;

class BinaryRepresentation
{
    static string GetBinary(short number)
    {
        StringBuilder str = new StringBuilder();

        for (int i = 0; i < 16; i++)
        {
            str.Append((number >> i & 1));
        }
        char[] array = str.ToString().ToArray();
        Array.Reverse(array);
        return (new string(array));
    }

    static void Main()
    {
        Console.WriteLine(GetBinary(56));
    }
}