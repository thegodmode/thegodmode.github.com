using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class QueueItem<T> 
{
    private T value;
    private QueueItem<T> nextItem;

    public QueueItem()
    {
    }

    public QueueItem(T value)
    {
        this.Value = value;
    }

    public T Value
    {
        get
        {
            return this.value;
        }
        set
        {
            this.value = value;
        }
    }

    public QueueItem<T> NextItem
    {
        get
        {
            return this.nextItem;
        }
        set
        {
            this.nextItem = value;
        }
    }
    
}