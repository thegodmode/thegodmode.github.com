using System;
using System.Collections.Generic;


class ShortestSequance
{ 
    static void Main(string[] args)
    {
        int startNumber = 5;  //Int32.Parse(Console.ReadLine());
        int targetNumber = 16; //Int32.Parse(Console.ReadLine());
        string path = FindShortestPath(startNumber, targetNumber);
        Console.WriteLine(path);
    }

    private static string FindShortestPath(int startNumber, int targetNumber)
    {
        Queue<ValuePathPair> que = new Queue<ValuePathPair>();
        que.Enqueue(new ValuePathPair(null, startNumber));
        var pair = que.Dequeue();

        do
        {
            if (pair.Value < targetNumber)
            {
                que.Enqueue(new ValuePathPair(pair.CurrentPath, pair.Value + 1));
                que.Enqueue(new ValuePathPair(pair.CurrentPath, pair.Value + 2));
                que.Enqueue(new ValuePathPair(pair.CurrentPath, pair.Value * 2));
            }
            
            pair = que.Dequeue();
        }
        while (pair.Value != targetNumber && que.Count != 0);
        
        return pair.CurrentPath;
    }
}