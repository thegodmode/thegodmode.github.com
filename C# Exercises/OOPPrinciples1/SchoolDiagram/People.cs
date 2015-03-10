using System;

namespace School.Common
{
    public class People : OptionalComments
    {
        private string name;
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name == null)
                {
                    throw new ArgumentNullException("Name cannot be null");
                }
                name = value;
            }
        }

        public People(string name, string optionalComments = "Empty")
            : base(optionalComments)
        {
            this.name = name;
        }
    }
}