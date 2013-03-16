using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ShootingRacket : Racket
    {
        bool isShooting = false;

        public ShootingRacket(int row, int col, int width) : base(new MatrixCoords(row,col), width)
        {
        }

        public bool IsShooting
        {
            private get
            {
                return isShooting;
            }
            set
            {
                isShooting = value;
            }
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.isShooting == true)
            {
                this.isShooting = false;
                return new List<GameObject>() {
                    new Bullet(this.TopLeft.Row - 1,(this.TopLeft.Col + this.Width / 2))
                };
            }
            else
            {
                return new List<GameObject>();
            }
        }
    }
}