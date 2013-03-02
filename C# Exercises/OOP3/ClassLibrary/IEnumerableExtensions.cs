using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public static class IEnumerableExtensions
    {
        private static T Calculate<T>(IEnumerable<T> list, Func<dynamic, T, T> expression)
        {
            IEnumerator<T> enumerator = list.GetEnumerator();
            dynamic total = null;
            enumerator.MoveNext();
            total = enumerator.Current;
            while (enumerator.MoveNext())
            {
                total = expression(enumerator.Current, total);
            }

            return total;
        }

        private static int Count<T>(IEnumerable<T> list)
        {
            int counter = 0;
            foreach (var item in list)
            {
                counter++;
            }

            return counter;
        }
      
        public static T Sum<T>(this IEnumerable<T> list)
        {
            return Calculate(list, (a, b) => a + b);
        }

        public static T Product<T>(this IEnumerable<T> list)
        {
            return Calculate(list, (a, b) => a * b);
        }

        public static T Max<T>(this IEnumerable<T> list)
        {
            return Calculate(list, (a, b) => a > b ? a : b);
        }

        public static T Min<T>(this IEnumerable<T> list)
        {
            return Calculate(list, (a, b) => a < b ? a : b);
        }

        public static double Average<T>(this IEnumerable<T> list)
        {
            
            double sum = Convert.ToDouble(Calculate(list, (a, b) => a + b));
            int count = Count(list);
            return sum/count;
        }
    }
}