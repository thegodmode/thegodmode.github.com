using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Classes
{
    public class Path
    {
        List<Point3D> sequence = new List<Point3D>();

        public List<Point3D> Sequence
        {
            get
            {
                return sequence;
            }
            
        }

        public void AddPoint(Point3D point)
        {
            sequence.Add(point);
        }
    }
}