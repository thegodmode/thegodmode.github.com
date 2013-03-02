using System;

namespace School.Common
{
    public class OptionalComments
    {
        string optionalComments;
       
        public OptionalComments(string optionalComments = "Empty")
        {
            this.optionalComments = optionalComments;
            
        }

        public string OptionalComments1
        {
            get
            {
                return optionalComments;
            }
            set
            {
                optionalComments = value;
            }
        }
    }
}