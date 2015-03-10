using System;
using System.Linq;

namespace Common.Classes
{
    public struct Point3D
    {
        private int x;
        private int y;
        private int z;
        private static Point3D startPoint;

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

        public int Z
        {
            get
            {
                return z;
            }
            
        }

        public static Point3D StartPoint
        {
            get
            {
                return startPoint;
            }
        }

        static Point3D()
        {
            startPoint = new Point3D(0, 0, 0);
        }

        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return string.Format("(X:{0},Y:{1},Z:{2})", x, y, z);
        }
    }
}