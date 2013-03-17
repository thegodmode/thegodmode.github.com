using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnpassableBlocks : IndestructibleBlock
    {
        public new const string CollisionGroupString = "unpassableblock";

        public UnpassableBlocks(MatrixCoords topLeft) : base(topLeft)
        {
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlocks.CollisionGroupString;
        }
    }
}