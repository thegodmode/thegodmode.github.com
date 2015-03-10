using System;
using System.Collections.Generic;
using WinHashTable;

public class HashedSet<T> : IEnumerable<T> where T : IEquatable<T>
{
    private readonly HashTable<T, T> arraySet;
    
    public HashedSet(int capacity = 16)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid capacity size" + capacity);
        }

        this.arraySet = new HashTable<T, T>(capacity);
    }

    public HashSet<T> Keys
    {
        get
        {
            return this.arraySet.Keys;
        }
    }

    public int Count
    {
        get
        {
            return this.arraySet.Count;
        }
    }

    public void Add(T value)
    {
        this.arraySet.Add(value, value);
    }

    public T Find(T value)
    {
        var item = this.arraySet.Find(value);
        return item;
    }

    public void Remove(T value)
    {
        this.arraySet.Remove(value);
    }

    public void Clear()
    {
        this.arraySet.Clear();
    }

    public bool Contain(T value)
    {
        return this.arraySet.Contain(value);
    }

    public void Union(HashedSet<T> hashSet)
    {
        foreach (var item in hashSet)
        {
            if (!this.Contain(item))
            {
                this.Add(item);
            }
        }
    }

    public HashedSet<T> Intersect(HashedSet<T> hashSet)
    {
        var resultSet = new HashedSet<T>();
        foreach (var item in hashSet)
        {
            if (this.Contain(item))
            {
                resultSet.Add(item);
            }
        }

        return resultSet;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var arrayListEnumerator = arraySet.GetEnumerator();
        while (arrayListEnumerator.MoveNext())
        {
            var currentLinkedList = arrayListEnumerator.Current;

            yield return currentLinkedList.Key;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}