using System;
using System.Collections.Generic;
using System.Linq;
using Common.Classes;

namespace TestGenericList
{
    [Version(1.21)]
    class TestGenericList
    {
        static void Main()
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            Console.WriteLine(list.Min());
            list.InsertAt(234, 2);
            list.Print();
            Console.WriteLine();
            // Remove at index
            list.RemoveAt(2);
            list.Print();
            Console.WriteLine();
            // insert At 
            list.InsertAt(234, 2);
            list.Print();
            // find At
            Console.WriteLine();
            Console.WriteLine(list.FindAt(0));      
            // Test Find Method - using delagates ... 
            Console.WriteLine(list.Find(delegate(int value)
            {
                return value == 72;
            }));
               
            list.Clear();
            list.Print();

            // using attribute 
            Type type = typeof(TestGenericList);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attr in allAttributes)
            {
                 Console.WriteLine("Version of class TestGenericList is {0:0.00}",attr.Version);
            }
            
           
        }
    }
}