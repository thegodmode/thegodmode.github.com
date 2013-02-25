using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CheckBracketsInExpression
{
    static void Main(string[] args)
    {
        string expression = ")(a+b))";
        int bracketsCounter = 0;
        for (int index = 0; index < expression.Length; index++)
        {
            if (expression[index] == '(')
            {
                bracketsCounter++;
            }
            if (expression[index]==')')
            {
                bracketsCounter--;
            }
           
        }

        if (bracketsCounter!=0)
        {
            Console.WriteLine("This expression has invalid brackets!");
        }
        else
        {
            Console.WriteLine("The expression is correct!");
        }
    }
}

