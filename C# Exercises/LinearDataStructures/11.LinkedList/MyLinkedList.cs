using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private ListItem<T> firstElement;
        private ListItem<T> lastElement;
        private int count = 0;
        
        public MyLinkedList()
        {
        }

        public MyLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            foreach (T item in collection)
            {
                this.AddLast(item);
            }
        }

        public ListItem<T> FirstElement
        {
            get
            {
                return this.firstElement;
            }
            private set
            {
                this.firstElement = value;
            }
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            var node = this.firstElement;
            while (node != null)
            {
                yield return node.Value;
                node = node.NextItem;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ListItem<T> AddLast(T value)
        {
            if (value == null)
            {
                throw new NullReferenceException("value");
            }

            if (firstElement == null)
            {
                this.firstElement = new ListItem<T>(value);
                this.lastElement = firstElement;
                count++;
            }
            else
            {
                ListItem<T> listNode = new ListItem<T>(value);
                lastElement.NextItem = listNode;
                lastElement = lastElement.NextItem;
                count++;
            }

            return this.lastElement;
        }

        public ListItem<T> AddFirst(T value)
        {
            if (value == null)
            {
                throw new NullReferenceException("value");
            }

            if (firstElement == null)
            {
                this.firstElement = new ListItem<T>(value);
                this.lastElement = firstElement;
                count++;
            }
            else
            {
                ListItem<T> listNode = new ListItem<T>(value);
                listNode.NextItem = firstElement;
                firstElement = listNode;
                count++;
            }

            return this.firstElement;
        }

        public ListItem<T> AddAfter(ListItem<T> node, T value)
        {
            if (value == null)
            {
                throw new NullReferenceException("value");
            }

            if (node == null)
            {
                throw new NullReferenceException("node");
            }

            if (node.NextItem == null)
            {
                node.NextItem = new ListItem<T>(value);
            }
            else
            {
                var next = node.NextItem;
                node.NextItem = new ListItem<T>(value);
                node.NextItem.NextItem = next;
            }

            return node.NextItem;
        }
               
        public void Clear()
        {
            var node = this.firstElement;
            this.firstElement = null;
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
            if (value==null)
            {
                throw new NullReferenceException("value");
            }
            var node = this.firstElement;

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
       
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void RemoveFirst()
        {
            if (this.firstElement == null)
            {
                throw new InvalidOperationException("LinkedListEmpty");
            }

            var node = firstElement.NextItem;
            this.firstElement = null;
            this.firstElement = node;
           
        }
    }
}