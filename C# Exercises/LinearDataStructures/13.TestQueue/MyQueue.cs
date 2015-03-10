using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MyQueue<T> : IEnumerable<T>
{
    private QueueItem<T> head;
    private QueueItem<T> tail;
    private int count;

    public MyQueue()
    {
    }

    public MyQueue(T value)
    {
        if (value == null)
        {
            throw new NullReferenceException("item"); 
        }
        this.Head = new QueueItem<T>(value);
        this.Tail = this.Head;
        this.count++;
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

    public void Enqueue(T value)
    {
        if (value == null)
        {
            throw new NullReferenceException("item");
        }

        if (head == null)
        {
            this.Head = new QueueItem<T>(value);
            this.Tail = this.Head;
        }
        else
        {
            this.Tail.NextItem = new QueueItem<T>(value);
            this.Tail = this.Tail.NextItem;
        }

        this.count++;
    }

    public T Dequeue()
    {
        if (this.Head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var currentHead = this.Head;
        this.Head = this.Head.NextItem;
        var value = currentHead.Value;
        currentHead = null;
        this.count--;
        return value;
    }

    public T Peek()
    {
        if (this.Head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var value = this.Head.Value;
        return value;
    }

    public void Clear()
    {
        if (this.Head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        
        var node = this.Head;
        this.Head = null;

        while (node.NextItem != null)
        {
            var next = node.NextItem;
            node = next;
            next = null;
        }

        this.count = 0;
    }

    public bool Contains(T value)
    {
        if (value == null)
        {
            throw new NullReferenceException("value");
        }
        var node = this.Head;

        do
        {
            if (node.Value.Equals(value))
            {
                return true;
            }
            node = node.NextItem;
        }
        while (node != null);

        return false;
    }

    public T[] ToArray()
    {
        if (this.Head == null)
        {
            throw new InvalidOperationException("The queue is empty");
        }

        var node = this.Head;
        T[] array = new T[this.Count];
        int index = 0;
        do
        {
            array[index++] = node.Value;
            node = node.NextItem;
        }
        while (node != null);

        return array;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        var node = this.Head;
        while (node != null)
        {
            yield return node.Value;
            node = node.NextItem;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private QueueItem<T> Tail
    {
        get
        {
            return this.tail;
        }
        set
        {
            this.tail = value;
        }
    }

    private QueueItem<T> Head
    {
        get
        {
            return this.head;
        }
        set
        {
            this.head = value;
        }
    }
}