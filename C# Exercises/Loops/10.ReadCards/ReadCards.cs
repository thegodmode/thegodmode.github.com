using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ReadCards
{


    static void Main(string[] args)
    {
        string[] color = { "spade", "heart", "diamond", "club" };
        for (int i = 0; i < 4; i++)
        {

            for (int index = 2; index < 15; index++)
            {
                switch (index)
                {
                    case 2: Console.Write(2 + "-" + color[i]+" "); break;
                    case 3: Console.Write(3 + "-" + color[i] + " "); break;
                    case 4: Console.Write(4 + "-" + color[i] + " "); break;
                    case 5: Console.Write(5 + "-" + color[i] + " "); break;
                    case 6: Console.Write(6 + "-" + color[i] + " "); break;
                    case 7: Console.Write(7 + "-" + color[i] + " "); break;
                    case 8: Console.Write(8 + "-" + color[i] + " "); break;
                    case 9: Console.Write(9 + "-" + color[i] + " "); break;
                    case 10: Console.Write(10 + "-" + color[i] + " "); break;
                    case 11: Console.Write("J" + "-" + color[i] + " "); break;
                    case 12: Console.Write("Q" + "-" + color[i] + " "); break;
                    case 13: Console.Write("K" + "-" + color[i] + " "); break;
                    case 14: Console.Write("A" + "-" + color[i] + " "); break;
                    default: Console.WriteLine("Unexpected Error!"); break;
                }
            }
            Console.WriteLine();
        }
    }
}

