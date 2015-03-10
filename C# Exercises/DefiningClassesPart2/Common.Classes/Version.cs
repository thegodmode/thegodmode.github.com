using System;
using System.Linq;

namespace Common.Classes
{
    [AttributeUsage(AttributeTargets.Struct |
        AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum |
        AttributeTargets.Method,
        AllowMultiple = true)]
    public class VersionAttribute : System.Attribute
    {
        public double Version
        {
            get;
            private set;
        }

        public VersionAttribute(double version)
        {
            this.Version = version;
        }
    }

    
}