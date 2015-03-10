using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumberUsingStack
{
    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            ReadUserNumbers(numbers);

            List<int> reverseList = Reverse(numbers);

            PrintOnConsole(reverseList);
        }

        private static void PrintOnConsole(List<int> reverseList)
        {
            Console.WriteLine(String.Join(", ", reverseList));
        }

        private static List<int> Reverse(Stack<int> numbers)
        {
            if (numbers == null)
            {
                throw new NullReferenceException("Given list can't be null" + numbers);
            }

            List<int> reversNumbers = new List<int>();
            while (numbers.Count != 0)
            {
                var currentNumber = numbers.Pop();
                reversNumbers.Add(currentNumber);
            }

            return reversNumbers;
        }

        private static void ReadUserNumbers(Stack<int> numbers)
        {
            Console.WriteLine("Enter empty line for end of sequance");
            var number = Console.ReadLine();

            while (!string.IsNullOrEmpty(number))
            {
                numbers.Push(int.Parse(number));
                number = Console.ReadLine();
            }
        }
    }
}