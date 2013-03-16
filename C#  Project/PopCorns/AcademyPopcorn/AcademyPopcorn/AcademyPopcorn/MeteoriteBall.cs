using System;
using System.Linq;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed) : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            return new List<GameObject>()
            {
                new TrialClass(this.TopLeft,3)

            };
        }
    }
}