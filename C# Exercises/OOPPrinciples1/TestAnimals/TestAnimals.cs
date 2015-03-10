using System;
using System.Collections.Generic;
using System.Linq;
using Animals.Common;

namespace TestAnimals
{
    class TestAnimals
    {
        static void Main(string[] args)
        {
            List<Dog> list = new List<Dog>() {
                new Dog("m",24, "Ivo"),
                new Dog("m",12, "Danu"),
                new Dog("m",10, "Ivan"),
            };

            List<Cat> newList = new List<Cat>() {
                new Kitten(24, "Iva"),
                new Tomcat(24, "Tom"),
                new Kitten(24, "Asq")
        };

            Console.WriteLine(Animal.AverageAge(newList));
            Console.WriteLine(Animal.AverageAge(list));    
    }
}
}