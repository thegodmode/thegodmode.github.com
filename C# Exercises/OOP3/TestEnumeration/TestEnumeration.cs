using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace TestEnumeration
{
    class TestEnumeration
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 21, 43, 125 };
            Console.WriteLine(list.Sum());
            Console.WriteLine(list.Product());
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Min());
            Console.WriteLine(list.Average());
        }
    }
}