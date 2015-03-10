using System;

namespace People.Common
{
    public abstract class Human
    { 
        private string fName;
        private string lName;

       
        public Human(string fName, string lName)
        {
            this.FName = fName;
            this.LName = lName;
        }

        public string LName
        {
            get
            {
                return lName;
            }
            set
            {
                if (value==null)
                {
                    throw new ArgumentException();
                }
                lName = value;
            }
        }

        public string FName
        {
            get
            {
                return fName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                }
                fName = value;
            }
        }
    }
}
