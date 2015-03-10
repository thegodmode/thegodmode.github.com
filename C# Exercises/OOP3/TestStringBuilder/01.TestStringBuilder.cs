using System;
using System.Linq;
using System.Text;
using ClassLibrary;


namespace TestStringBuilder
{
    class TestStringBuilder
    {
        static void Main(string[] args)
        {
            StringBuilder test = new StringBuilder("niso");
            Console.WriteLine(test.Substring(0,2));
            Console.WriteLine(test.Substring(2));
              
           
        }
    }
}
