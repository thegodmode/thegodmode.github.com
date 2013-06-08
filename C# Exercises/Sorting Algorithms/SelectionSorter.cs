namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int minIndex;

            for (int i = 0; i < collection.Count - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if ((collection[j].CompareTo(collection[minIndex]) < 1))
                    {
                        minIndex = j;
                    }
                }

                var exchangeValue = collection[i];
                collection[i] = collection[minIndex];
                collection[minIndex] = exchangeValue;
            }
        }
    }
}