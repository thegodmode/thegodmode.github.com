using System;

namespace Animals.Common
{
    public class Frog:Animal
    {

        public Frog(string sex, int age, string name) : base(sex, age, name)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("I am Frog");
        }
    }
}
