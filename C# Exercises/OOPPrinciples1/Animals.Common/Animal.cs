using System;
using System.Collections;
using System.Collections.Generic;

namespace Animals.Common
{
    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        private string sex;
       
        protected Animal(string sex, int age, string name)
        {
            this.Sex = sex;
            this.Age = age;
            this.Name = name;
        }

        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public static double AverageAge(IEnumerable<Animal> array)
        {
            double sum = 0;
            int counter = 0;
            foreach (var item in array)
            {
                sum += item.Age;
                counter++;
            }

            return sum / counter;
        }

        public abstract void ProduceSound();
    }
}