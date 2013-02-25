using System;
using System.Linq;


namespace DefiningClasses.Common
{
    public class Display
    {
        private double? height;
        private double? width;
        private int? numberOfColors;

        public Display(double? height = null, double? width = null, int? numberOfColors = null)
        {
            if (height < 0 || width < 0 || numberOfColors < 0)
            {
                throw new ArgumentException("Display  values must be positive");
            }
            this.height = height;
            this.width = width;
            this.numberOfColors = numberOfColors;
        }
        
        public int? NumberOfColors
        {
            get
            {
                return numberOfColors;
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Colors must be postive number");
                }
                numberOfColors = value;
            }
        }

        public double? Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width must be postive number");
                }
                width = value;
            }
        }

        public double? Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height must be postive number");
                }
                height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("  -Height: {0}\n  -Width: {1}\n  -NumberOfColors: {2}", height, width, numberOfColors);
        }
    }
}