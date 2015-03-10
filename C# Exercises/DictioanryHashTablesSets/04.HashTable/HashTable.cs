using System;
using System.Linq;
using System.Collections.Generic;

namespace WinHashTable
{
    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>> where K : IEquatable<K>
    {
        private LinkedList<KeyValuePair<K, T>>[] keyValueList;
        private int capacity;
        private int count;
        private int currentListLength = 0;
        private HashSet<K> keys;

        public HashTable(int capacity = 16)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid capacity size" + capacity);
            }

            this.Capacity = capacity;
            this.KeyValueArray = new LinkedList<KeyValuePair<K, T>>[this.Capacity];
            this.Keys = new HashSet<K>();
            this.count = 0;
        }

        public HashSet<K> Keys
        {
            get
            {
                return this.keys;
            }
            private set
            {
                this.keys = value;
            }
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                SetKeyValue(key, value);
            }
        }

        private void SetKeyValue(K key, T value)
        {
            int hashCode = key.GetHashCode() & 2147483647;
            int index = hashCode % this.KeyValueArray.Length;
            if (this.KeyValueArray[index] == null)
            {
                throw new ArgumentNullException("This key doesn't exist");
            }
            else
            {
                foreach (var item in this.keyValueList[index])
                {
                    if (item.Key.Equals(key))
                    {
                        this.keyValueList[index].Remove(item);
                        var newPair = new KeyValuePair<K, T>(key, value);
                        this.keyValueList[index].AddFirst(newPair);
                        return;
                    }
                }
            }
            throw new ArgumentNullException("This key doesn't exist");
        }

        public T Find(K key)
        {
            int index = key.GetHashCode() % this.keyValueList.Length;
            if (this.keyValueList[index] == null)
            {
                throw new ArgumentException("The element with this key doesn't exist");
            }
            else
            {
                foreach (var item in this.keyValueList[index])
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }

                throw new ArgumentException("There is no element with this key");
            }
        }

        public void Remove(K key)
        {
            int index = key.GetHashCode() % this.keyValueList.Length;
            if (this.keyValueList[index] == null)
            {
                throw new ArgumentException("The element with this key doesn't exist");
            }
            else
            {
                foreach (var item in this.keyValueList[index])
                {
                    if (item.Key.Equals(key))
                    {
                        this.keyValueList[index].Remove(item);
                        this.Count--;
                        keys.Remove(key);
                        return;
                    }
                }
            }
            throw new ArgumentException("The element with this key doesn't exist");
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

        private int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                this.capacity = value;
            }
        }

        private LinkedList<KeyValuePair<K, T>>[] KeyValueArray
        {
            get
            {
                return this.keyValueList;
            }
            set
            {
                this.keyValueList = value;
            }
        }
       
        public void Add(K key, T value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key cant'be null");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value cant'be null");
            }

            if (this.currentListLength > this.KeyValueArray.Length * 0.75)
            {
                ExpandArray();
            }

            int hashCode = key.GetHashCode() & 2147483647;
            int index = hashCode % this.KeyValueArray.Length;
            if (this.KeyValueArray[index] == null)
            {
                this.keyValueList[index] = new LinkedList<KeyValuePair<K, T>>();
                this.currentListLength++;
            }
            else
            {
                foreach (var item in this.keyValueList[index])
                {
                    if (item.Key.Equals(key))
                    {
                        throw new ArgumentException("The key is already Added. key:" + key);
                    }
                }
            }

            this.Keys.Add(key);
            var newPair = new KeyValuePair<K, T>(key, value);
            this.KeyValueArray[index].AddFirst(newPair);
            this.Count++;
        }

        private void ExpandArray()
        {
            var expandArray = new LinkedList<KeyValuePair<K, T>>[this.Capacity * 2];
            Array.Copy(this.KeyValueArray, expandArray, this.Capacity);
            this.KeyValueArray = expandArray;
            this.Capacity *= 2;
        }

        public void Clear()
        {
            foreach (var list in keyValueList)
            {
                if (list != null)
                {
                    list.Clear();
                }
            }
            this.Count = 0;
        }

        public bool Contain(K key)
        {
            int index = key.GetHashCode() % this.keyValueList.Length;
            if (this.keyValueList[index] == null)
            {
                return false;
            }
            else
            {
                foreach (var item in this.keyValueList[index])
                {
                    if (item.Key.Equals(key))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            var arrayListEnumerator = KeyValueArray.GetEnumerator();
            while (arrayListEnumerator.MoveNext())
            {
                if (arrayListEnumerator.Current != null)
                {
                    var currentLinkedList = (LinkedList<KeyValuePair<K, T>>)arrayListEnumerator.Current;
                    var linkedListEnumerator = currentLinkedList.GetEnumerator();
                    while (linkedListEnumerator.MoveNext())
                    {
                        yield return linkedListEnumerator.Current;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}