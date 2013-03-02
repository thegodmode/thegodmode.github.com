using System;

namespace School.Common
{
    public class People : OptionalComments
    {
        private string name;

        public People(string name)
        {
            this.Name = name;
        }

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
                    throw new ArgumentNullException("Name cannot be null");
                }
                name = value;
            }
        }

        
            
    }
}