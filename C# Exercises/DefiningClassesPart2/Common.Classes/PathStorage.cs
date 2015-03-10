using System;
using System.IO;
using System.Linq;

namespace Common.Classes
{
    public static class PathStorage
    {
        static Path path = new Path();

        public static void LoadPathFromTextFile(string textFilePath)
        {
            using (StreamReader reader = new StreamReader(textFilePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] args = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                    Point3D newPoint = new Point3D(Int32.Parse(args[0]), Int32.Parse(args[1]), Int32.Parse(args[2]));
                    path.AddPoint(newPoint);
                }
            }
        }

        public static void SavePathToTextFile(string textFileName)
        {
            using (StreamWriter writer = new StreamWriter(textFileName))
            {
                string line = null;
                foreach (var item in path.Sequence)
                {
                    writer.WriteLine("{0} {1} {2}", item.X, item.Y, item.Z);
                }
            }
        }
    }
}