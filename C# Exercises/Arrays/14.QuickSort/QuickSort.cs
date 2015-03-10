using System;
using System.Linq;

class QuickSort
{
    static public int Partition(int[] numbers, int left, int right)
    {
        int pivot = numbers[left];
        while (true)
        {
            while (numbers[left] < pivot)
            {
                left++;
            }
            while (numbers[right] > pivot)
            {
                right--;
            }
            if (left < right)
            {
                int temp = numbers[right];
                numbers[right] = numbers[left];
                numbers[left] = temp;
            }
            else
            {
                return right;
            }
        }
    }

    static public void QuickSort_Recursive(int[] arr, int left, int right)
    {
        // For Recusrion
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            if (pivot > 1)
                QuickSort_Recursive(arr, left, pivot - 1);

            if (pivot + 1 < right)
                QuickSort_Recursive(arr, pivot + 1, right);
        }
    }

    static void Main(string[] args)
    {
        int[] myArray =
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
        int len = myArray.Length;
        QuickSort_Recursive(myArray, 0, len - 1);
        for (int i = 0; i < myArray.Length; i++)
        {
            Console.Write(myArray[i] + " ");
        }
        Console.WriteLine();
    }
}