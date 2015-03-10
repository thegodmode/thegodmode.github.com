﻿using System;
using System.Threading;

class Program
{
    public delegate void myDelegate();

    public static event myDelegate myEvent;

    public static EventHandler<string> secondEvent;

    static void Main()
    {
        myEvent = SayHi;
        myEvent += SayBay;
        myEvent += () => Console.WriteLine("Another Handler!");
        myEvent += delegate()
        {
            Console.WriteLine("It's Work");
        };

        secondEvent = printMyString;

        while (true)
        {
            myEvent();
            secondEvent(null, "Ivo Andonov maika !");
            Thread.Sleep(2000);
        }
    }

    private static void printMyString(object sender, string s)
    {
        Console.WriteLine(s);
    }
        
    static void SayHi()
    {
        Console.WriteLine("Hello Stranger");
    }

    static void SayBay()
    {
        Console.WriteLine("Bay Stranger");
    }
}