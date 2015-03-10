using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft) : base(topLeft)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed == true)
            {
                return new List<GameObject>() {
                    new Explosion(new MatrixCoords(this.topLeft.Row + 1,this.TopLeft.Col),new char[,]{{' '}}),
                    new Explosion(new MatrixCoords(this.topLeft.Row - 1,this.TopLeft.Col),new char[,]{{' '}}),
                    new Explosion(new MatrixCoords(this.topLeft.Row,this.TopLeft.Col - 1),new char[,]{{' '}}),
                    new Explosion(new MatrixCoords(this.topLeft.Row,this.TopLeft.Col + 1),new char[,]{{' '}}),
                };
            }

            return new List<GameObject>();
        }
    }
}