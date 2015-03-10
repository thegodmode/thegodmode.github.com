using System;
using System.Linq;
using Common.Classes;

namespace TestPathStorage
{
    class TestPathStorage
    {
        static void Main()
        {
            PathStorage.LoadPathFromTextFile("ReadFile.txt");
            PathStorage.SavePathToTextFile("NewFile.txt");

            
        }
    }
}
