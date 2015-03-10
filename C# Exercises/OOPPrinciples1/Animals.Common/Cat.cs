using System;
using System.Linq;

namespace Animals.Common
{
    public  class Cat : Animal
    {
        public Cat(string sex, int age, string name) : base(sex, age, name)
        {
        }


        public override void ProduceSound()
        {
            Console.WriteLine("Maayyyyyy");
        }
    }
}