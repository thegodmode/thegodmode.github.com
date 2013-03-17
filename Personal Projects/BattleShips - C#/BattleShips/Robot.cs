using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public static class Robot
    {
        public static MatrixCoordinates GenerateShot()
        {
            Random rnd = new Random();
            return new MatrixCoordinates(rnd.Next(1, 11),rnd.Next(1, 21));
        }
    }
}