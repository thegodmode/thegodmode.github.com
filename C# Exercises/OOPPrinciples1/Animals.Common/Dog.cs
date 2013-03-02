using System;

namespace Animals.Common
{
    public class Dog : Animal
    {

        public Dog(string sex, int age, string name) : base(sex, age, name)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("I am Dog");
        }
    }
}