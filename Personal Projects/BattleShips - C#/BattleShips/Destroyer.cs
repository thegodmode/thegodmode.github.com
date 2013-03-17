using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShips
{
    public class Destroyer : Ship
    {
        public new const int Length = 3;
        public new const char Symbol = 'D';
        public Destroyer(Orientation orientation, MatrixCoordinates topLeft) : base(orientation, topLeft)
        {
        }

        public override int GetShipLength()
        {
            return Destroyer.Length;
        }

        public override char GetSymbol()
        {
            return Destroyer.Symbol;
        }
    }
}
