using System;
using System.Collections.Generic;

namespace School.Common
{
    public class OptionalComments
    {
        List<string> optionalComments;

        public OptionalComments()
        {
            this.optionalComments = new List<string>();
        }

        public override string ToString()
        {
            return string.Format("OptionalComments1: {0}\n", this.OptionalComments1);
        }

        public List<string> OptionalComments1
        {
            get
            {
                if (optionalComments.Count == 0)
                {
                    return new List<string>() { "Empty" };
                }
                return optionalComments;
            }
         
        }

        public void AddComment(string comment)
        {
            if (comment!=null)
            {
                this.optionalComments.Add(comment);
            }
            else
            {
                throw new ArgumentNullException();
            }
            
        }
    }
}