namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            MergeSort(collection);
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            // Recursion Stop - Hit the Bottom !
            if (collection.Count == 1)
            {
                return collection;
            }

            //Create two arrays and put values from 'array' in them
            int leftArrayLength = collection.Count / 2;
            int rightArrayLength = collection.Count - leftArrayLength;
            IList<T> leftArray = new List<T>(leftArrayLength);
            IList<T> rightArray = new List<T>(rightArrayLength);

            for (int index = 0; index < leftArrayLength; index++)
            {
                leftArray.Add(collection[index]);
            }

            for (int index = 0; index < rightArrayLength; index++)
            {
                rightArray.Add(collection[index + leftArrayLength]);
            }

            leftArray = MergeSort(leftArray); //Recursion for leftArray
            rightArray = MergeSort(rightArray);//Recursion for rightArray

            return SortedArray(leftArray, rightArray, collection.Count);
        }

        // make new sorted array from 'leftarray' and 'rightarray'
        private IList<T> SortedArray(IList<T> leftArray, IList<T> rightArray, int length)
        {
            IList<T> sortedArray = new List<T>(length);
            int leftArrayIndex = 0;
            int rightArrayIndex = 0;
            for (int i = 0; i < length; i++)
            {
                if (leftArrayIndex < leftArray.Count && rightArrayIndex < rightArray.Count)
                {
                    if ((leftArray[leftArrayIndex].CompareTo(rightArray[rightArrayIndex])) < 0)
                    {
                        sortedArray.Add(leftArray[leftArrayIndex++]);
                    }
                    else
                    {
                        sortedArray.Add(rightArray[rightArrayIndex++]);
                    }
                }
                else
                {
                    if (leftArrayIndex < leftArray.Count)
                    {
                        sortedArray.Add(leftArray[leftArrayIndex++]);
                    }
                    else
                    {
                        sortedArray.Add(rightArray[rightArrayIndex++]);
                    }
                }
            }
            return sortedArray;
        }
    }
}