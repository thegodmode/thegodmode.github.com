using System;
using System.Linq;

namespace Common.Classes
{
    public class GenericList<T> where T : IComparable
    {
        private T[] list;
        private int index = 0;
        private int length = 0;

        public GenericList()
        {
            this.list = new T[length];
        }

        public T[] List
        {
            get
            {
                return list;
            }
        }

        public void Add(T item)
        {
            if (index > list.Length - 1)
            {
                ExpandCapacity();
            }

            list[index] = item;
            index++;
        }

        public void RemoveAt(int position)
        {
            if (position < 0)
            {
                throw new IndexOutOfRangeException("Index must be positive");
            }

            if (position > this.index)
            {
                throw new IndexOutOfRangeException("Index out of Range");
            }
            Array.Copy(this.list, position + 1, this.list, position, this.index - position);
            this.index--;
        }

        public void Print()
        {
            for (int i = 0; i < index; i++)
            {
                Console.Write("{0} ", list[i]);
            }
        }

        public void Clear()
        {
            if (this.index > 0)
            {
                Array.Clear(list, 0, index);
                this.index = 0;
            }
        }

        public void InsertAt(T element, int position)
        {
            if (position > this.index || position < 0)
            {
                throw new IndexOutOfRangeException("Invalid Position");
            }

            if (this.index == list.Length)
            {
                ExpandCapacity();
            }
            if (position < this.index)
            {
                Array.Copy(this.list, position, this.list, position + 1, this.index - position);
            }
            this.list[position] = element;
            this.index++;
        }

        public T Find(Predicate<T> value)
        {
            if (value == null)
            {
                throw new ArgumentException("Value cant be null");
            }

            for (int i = 0; i < index + 1; i++)
            {
                if (value(this.list[i]))
                {
                    return this.list[i];
                }
            }

            return default(T);
        }

        public T FindAt(int position)
        {
            if (position < 0 || position > this.index)
            {
                throw new IndexOutOfRangeException("Invalid position");
            }

            return this.list[position];
        }

        public T Min() 
        {
            T minValue = this.list[0];
            for (int i = 0; i < this.index; i++)
            {
                if (this.list[i].CompareTo(minValue) < 0)
                {
                    minValue = this.list[i];
                }
            }

            return minValue;
        }

        public T Max()
        {
            T maxValue = this.list[0];
            for (int i = 0; i < this.index; i++)
            {
                if (this.list[i].CompareTo(maxValue) > 0)
                {
                    maxValue = this.list[i];
                }
            }

            return maxValue;
        }

        private void ExpandCapacity()
        {
            if (this.length == 0)
            {
                this.length = 4;
                this.list = new T[this.length];
            }
            else
            {
                this.length *= 2;
                T[] tempArray = new T[this.length];
                Array.Copy(this.list, tempArray, this.index);
                this.list = tempArray;
            }
        }
    }
}