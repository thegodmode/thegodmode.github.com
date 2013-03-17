using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShips
{
    public class Submarine : Ship
    {
        public new const int Length = 3;
        public new const char Symbol = 'S';
        public Submarine(Orientation orientation, MatrixCoordinates topLeft) : base(orientation, topLeft)
        {
        }

        public override int GetShipLength()
        {
            return Submarine.Length;
        }

        public override char GetSymbol()
        {
            return Submarine.Symbol;
        }
    }
}