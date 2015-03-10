using System;
using System.Text;

namespace School.Common
{
    public class Discipline : OptionalComments
    {
        int numberOfLecture;
        int numberOfExercises;
        string name;
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                name = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return numberOfExercises;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number Of Exercises can not be less then zero!");
                }
                numberOfExercises = value;
            }
        }

        public int NumberOfLecture
        {
            get
            {
                return numberOfLecture;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number Of Lectures can not be less then zero!");
                }
                numberOfLecture = value;
            }
        }

        public Discipline(string name, int numberOfLecture, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLecture = numberOfLecture;
            this.NumberOfExercises = numberOfExercises;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(string.Format("     -Name:{0}\n     -NumberOfExercises:{1}\n     -NumberOfLecture:{2}\n     -DisciplineComments:", this.Name, this.NumberOfExercises, this.NumberOfLecture));
            foreach (var item in this.OptionalComments1)
            {
                str.Append(item);
            }
            return str.ToString();
        }
    }
}