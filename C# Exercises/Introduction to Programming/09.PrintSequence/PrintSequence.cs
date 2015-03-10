using System;

class PrintSequence
{
    static void Main(string[] args)
    {
        for (int index = 2; index < 12; index=index+2)
        {
            Console.Write(" {0},-{1}",index,index+1);
        }

        Console.WriteLine();
    }
}

