using System;

namespace School.Common
{
    public class Discipline : People
    {
        int numberOfLecture;
        int numberOfExercises;
        
        public int NumberOfExercises
        {
            get
            {
                return numberOfExercises;
            }
            set
            {
                if (numberOfExercises < 0)
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
                if (numberOfLecture < 0)
                {
                    throw new ArgumentOutOfRangeException("Number Of Lectures can not be less then zero!");
                }
                numberOfLecture = value;
            }
        }

        public Discipline(string name, int numberOfLecture, int numberOfExercises, string optionalComments = "Empty")
            : base(name, optionalComments)
        {
            this.numberOfLecture = numberOfLecture;
            this.numberOfExercises = numberOfExercises;
        }

        public override string ToString()
        {
            return string.Format("Name:{0}, NumberOfExercises:{1}, NumberOfLecture:{2}", this.Name, this.NumberOfExercises, this.NumberOfLecture);
        }
    }
}