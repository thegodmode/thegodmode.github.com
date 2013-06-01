using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class MyStack <T> : IEnumerable<T>
{
    private T[] innerArray;
    private int count;
    
    public MyStack()
    {
        this.innerArray = new T[10];
        this.Count = 0;
    }

    public MyStack(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException("capacity must be not negative number");
        }
        
        this.innerArray = new T[capacity];
        this.Count = 0;
    }

    public void Push(T item)
    {
        if (item == null)
        {
            throw new NullReferenceException("item");
        }

        if (count == innerArray.Length)
        {
            T[] newArray = new T[2 * this.innerArray.Length];
            Array.Copy(this.innerArray, 0, newArray, 0, this.Count);
            this.innerArray = newArray;
        }
       
        this.innerArray[count] = item;
        this.Count++;
    }

    public T Pop()
    {
        if (this.innerArray.Length == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        var lastIndex = this.count - 1;
        var element = this.innerArray[lastIndex];
        this.innerArray[lastIndex] = default(T);
        this.count--;
        return element;
    }

    public T Peek()
    {
        if (this.innerArray.Length == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        var firstElement = this.innerArray[this.count - 1];
        return firstElement;
    }

    public int Count
    {
        get
        {
            return this.count;
        }
        private set
        {
            this.count = value;
        }
    }

    public void Clear()
    {
        Array.Clear(this.innerArray, 0, this.count);
        this.count = 0;
    }

    public bool Contains(T value)
    {
        for (int index = 0; index < this.count; index++)
        {
            if (this.innerArray[index].Equals(value))
            {
                return true;
            }
        }

        return false;
    }

    public T[] ToArray()
    {
        T[] newArray = new T[this.count];
        for (int i = 0; i < this.count; i++)
        {
            newArray[i] = this.innerArray[this.count - i - 1];
        }

        return newArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = count - 1; i >= 0; i--)
        {
            yield return this.innerArray[i];
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}