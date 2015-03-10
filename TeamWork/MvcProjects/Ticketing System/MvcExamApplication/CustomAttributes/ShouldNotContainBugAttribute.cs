namespace MvcExamApplication.CustomAttributes
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using System;
    
    using System.ComponentModel.DataAnnotations;

    public class ShouldNotContainBugAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }

            if (valueAsString.ToLower().Contains("Bug".ToLower()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}