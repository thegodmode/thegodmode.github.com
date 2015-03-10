using System;
using System.Linq;

namespace Common.Classes
{
    public static class Distance
    {
        public static double Get3DDistance(Point3D point1, Point3D point2)
        {
            int distance =(point1.X - point2.X) * (point1.X - point2.X) +
                (point1.Y - point2.Y) * (point1.Y - point2.Y) +
                (point1.Z - point2.Z) * (point1.Z - point2.Z);

            return Math.Sqrt(distance);
        }
    }
}