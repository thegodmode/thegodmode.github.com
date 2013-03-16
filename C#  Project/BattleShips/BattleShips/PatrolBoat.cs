using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShips
{
    public class PatrolBoat : Ship
    {
        public new const int Length = 2;
        public new const char Symbol = 'P';
        public PatrolBoat(Orientation orientation, MatrixCoordinates topLeft) : base( orientation, topLeft)
        {
            
        }
        public override int GetShipLength()
        {
            return PatrolBoat.Length;
        }

        public override char GetSymbol()
        {
            return PatrolBoat.Symbol;
        }
    }
}
