using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        string input = "So<rev><toogle></toogle></rev>";
        //bool inUpperCase = false;
        //bool inLower = false;
        //bool inToogle = false;
        //bool inDel = false;
        //bool inReverse = false;
        bool inBrackets = false;
        StringBuilder result = new StringBuilder();
        StringBuilder formatingText = new StringBuilder();
        StringBuilder formater = new StringBuilder();
        
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '<')
            {
                inBrackets = true;
            }
            else if (input[i] == '>')
            {
                inBrackets = false;
                formater.Append(" ");
                
            }
            else if (inBrackets && input[i]=='/')
            {
                inBrackets = false;
                while (input[i] != '>')
                {
                    i++;
                }
            }
            else if (inBrackets)
            {
                formater.Append(input[i]);
            }
          
            else
            {
                result.Append(input[i]);
            }
        }

        Console.WriteLine(result.ToString());
    }
}