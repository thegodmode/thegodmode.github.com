using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Explosion : GameObject
    {
        
        
        public Explosion(MatrixCoords topLeft, char[,] body) : base(topLeft, body)
        {
        }

        public override void Update()
        {
        }

      
    }
}