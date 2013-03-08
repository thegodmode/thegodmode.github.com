using System;
using Persons.Common;

namespace TestPerson
{
    class TestPerson
    {
        static void Main()
        {
            Person per = new Person("Kykata");
            Console.WriteLine(per);
            Person per1 = new Person("Ivo",43);
            Console.WriteLine(per1);
        }
    }
}
