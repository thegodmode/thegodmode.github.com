using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShips
{
    public class AircraftCarrier : Ship
    {
        public new const int Length = 5;
        public new const char Symbol = 'A';
        public AircraftCarrier(Orientation orientation, MatrixCoordinates topLeft) : base(orientation, topLeft)
        {

        }

        public override int GetShipLength()
        {
            return AircraftCarrier.Length;
        }

        public override char GetSymbol()
        {
            return AircraftCarrier.Symbol;
        }
    }
}
