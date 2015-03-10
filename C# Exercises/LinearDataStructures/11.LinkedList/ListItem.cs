using System;
using System.Linq;

namespace LinkedList
{
    public class ListItem<T>
    {
        T value;
        ListItem<T> nextItem;

        public ListItem()
        {
        }

        public ListItem(T value)
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

        public ListItem<T> NextItem
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
}