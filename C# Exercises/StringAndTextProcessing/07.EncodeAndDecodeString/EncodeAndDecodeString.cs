using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class EncodeAndDecodeString
{
    static void Main(string[] args)
    {
        string text = "bojidar";
        string cipher = "password12345";
        string endcodeText = (EncodeString(text, cipher));
        Console.WriteLine(endcodeText);
        Console.WriteLine(DecodeString(endcodeText, cipher));
    }

    static string EncodeString(string text, string cipher)
    {

        char result;
        int cipherIndex = 0;
        StringBuilder str = new StringBuilder(text.Length);
        for (int index = 0; index < text.Length; index++)
        {
            if (cipherIndex == cipher.Length)
            {
                cipherIndex = 0;
            }
            result = (char)((uint)text[index] ^ (uint)cipher[cipherIndex++]);
            str.Append(result);
        }
        return str.ToString();
    }

    static string DecodeString(string endcodeText, string cipher)
    {
        char result;
        int cipherIndex = 0;
        StringBuilder str = new StringBuilder(endcodeText.Length);
        for (int index = 0; index < endcodeText.Length; index++)
        {
            if (cipherIndex == cipher.Length)
            {
                cipherIndex = 0;
            }
            result = (char)((uint)endcodeText[index] ^ (uint)cipher[cipherIndex++]);
            str.Append(result);
        }
        return str.ToString();
    }

}

