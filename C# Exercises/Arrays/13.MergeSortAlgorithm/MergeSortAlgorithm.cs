using System;
using System.Linq;


class MergeSortAlgorithm
{
    static int[] myArray =
    {
        16,
        42,
        52,
        13,
        56,
        87,
        89,
        25,
        40,
        99,
        11,
        31
    };

    static void Main(string[] args)
    {
        //Program start Here
        myArray = MergeSort(myArray);
        //Print Sorted Array on Console
        for (int index = 0; index < myArray.Length; index++)
        {
            Console.Write(myArray[index] + " ");
        }
    }

    // Merge Sort Recurse Algorithm
    static int[] MergeSort(int[] array)
    {
        // Recursion Stop - Hit the Bottom !
        if (array.Length == 1)
        {
            return array;
        }
        //Create two arrays and put values from 'array' in them
        int leftArrayLength = array.Length / 2;
        int rightArrayLength = array.Length - leftArrayLength;
        int[] leftArray = new int[leftArrayLength];
        int[] rightArray = new int[rightArrayLength];
        for (int index = 0; index < leftArrayLength; index++)
        {
            leftArray[index] = array[index];
        }
        for (int index = 0; index < rightArrayLength; index++)
        {
            rightArray[index] = array[index + leftArrayLength];
        }

        leftArray = MergeSort(leftArray); //Recursion for leftArray
        rightArray = MergeSort(rightArray);//Recursion for rightArray

        return SortedArray(leftArray, rightArray, array.Length);
    }

    // make new sorted array from 'leftarray' and 'rightarray'
    static int[] SortedArray(int[] leftArray, int[] rightArray, int length)
    {
        int[] sortedArray = new int[length];
        int leftArrayIndex = 0;
        int rightArrayIndex = 0;
        for (int i = 0; i < length; i++)
        {
            if (leftArrayIndex < leftArray.Length && rightArrayIndex < rightArray.Length)
            {
                if (leftArray[leftArrayIndex] < rightArray[rightArrayIndex])
                {
                    sortedArray[i] = leftArray[leftArrayIndex++];
                }
                else
                {
                    sortedArray[i] = rightArray[rightArrayIndex++];
                }
            }
            else
            {
                if (leftArrayIndex < leftArray.Length)
                {
                    sortedArray[i] = leftArray[leftArrayIndex++];
                }
                else
                {
                    sortedArray[i] = rightArray[rightArrayIndex++];
                }
            }
        }
        return sortedArray;
    }
}