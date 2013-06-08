namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> elements, int left, int right)
        {
            int firstIndex = left, lastIndex = right;
            var pivot = elements[(left + right) / 2];
   
            while (firstIndex <= lastIndex)
            {
                while (elements[firstIndex].CompareTo(pivot) < 0)
                {
                    firstIndex++;
                }
   
                while (elements[lastIndex].CompareTo(pivot) > 0)
                {
                    lastIndex--;
                }
   
                if (firstIndex <= lastIndex)
                {
                    // Swap
                    var tmp = elements[firstIndex];
                    elements[firstIndex] = elements[lastIndex];
                    elements[lastIndex] = tmp;
   
                    firstIndex++;
                    lastIndex--;
                }
            }
   
            // Recursive calls
            if (left < lastIndex)
            {
                QuickSort(elements, left, lastIndex);
            }
   
            if (firstIndex < right)
            {
                QuickSort(elements, firstIndex, right);
            }
        }
    }
}