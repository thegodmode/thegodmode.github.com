using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearDataStructures
{
    class ReadNumbers
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            ReadUserNumbers<int>(list);

            int sum = CalculateSum<int>(list);
            Console.WriteLine(sum);
           
            int average = Average<int>(list);
            Console.WriteLine(average);
        }

        /// <summary>
        /// Calculate the average for given list
        /// </summary>
        private static T Average<T>(List<T> list) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (list == null)
            {
                throw new NullReferenceException("Given list can't be null" + list);
            }

            if (list.Count == 0)
            {
                throw new ArgumentException("Given list can't be empty" + list);
            }

            T sum = default(T);
            int length = list.Count;

            foreach (dynamic item in list)
            {
                sum += item;
            }

            T average = (dynamic)sum / length;
            return average;
        }

        /// <summary>
        /// Read input user numbers from the console
        /// </summary>
        private static void ReadUserNumbers<T>(List<T> list)
        {
            if (list == null)
            {
                throw new NullReferenceException("Given list can't be null" + list);
            }

            Console.WriteLine("Enter empty line for end of sequance");
            var number = Console.ReadLine();
            
            while (!string.IsNullOrEmpty(number))
            {
                list.Add((T)Convert.ChangeType(number, typeof(T)));
                number = Console.ReadLine();
            }
        }

        /// <summary>
        /// Calculate the sum for given list
        /// </summary>
        private static T CalculateSum<T>(List<T> list) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            if (list == null)
            {
                throw new NullReferenceException("Given list can't be null" + list);
            }

            T sum = default(T);
            foreach (dynamic item in list)
            {
                sum += item;
            }
            return sum;
        }
    }
}