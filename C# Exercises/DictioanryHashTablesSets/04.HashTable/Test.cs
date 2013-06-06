using System;
using System.Collections.Generic;

class Test
{
    static void Main(string[] args)
    {
        HashTable<int, int> hashTable = new HashTable<int, int>(2);
        hashTable.Add(3, 4);
        hashTable.Add(7, 4);
        Console.WriteLine(hashTable.Count);
        hashTable.Remove(3);
        Console.WriteLine(hashTable.Count);
        hashTable.Add(3, 4);
        hashTable.Add(8, 4);
        hashTable.Add(13, 4);
        hashTable.Add(3333, 4);
        hashTable.Add(124, 4);
        hashTable.Add(412412, 4);
        hashTable[8] = 25;
        hashTable[8] = -45;
        Console.WriteLine(hashTable.Count);
        foreach (var item in hashTable)
        {
            Console.WriteLine("Key {0}, Value {1}", item.Key, item.Value);
        }
        // Console.WriteLine(hashTable.Count);

        // Console.WriteLine(hashTable.Find(3));

        IEnumerable<int> keys = hashTable.Keys;

        foreach (var key in keys)
        {
            Console.Write(key + ",");
        }
        Console.WriteLine();
        hashTable.Add(17, 34);
        hashTable.Remove(8);
        hashTable.Remove(3333);
        keys = hashTable.Keys;

        foreach (var key in keys)
        {
            Console.Write(key + ",");
        }
        Console.WriteLine();
        hashTable.Clear();
        Console.WriteLine(hashTable.Count);
        foreach (var item in hashTable)
        {
            Console.WriteLine("Key {0}, Value {1}", item.Key, item.Value);
        }
    }
}