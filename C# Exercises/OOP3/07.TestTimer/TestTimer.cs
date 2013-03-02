using System;
using System.Linq;
using ClassLibrary;

class TestTimer
{
    static void Main()
    {
        Timer.RepeatAfter(2000, delegate()
        {
            Console.WriteLine("Hi");
            
        });
    }
}