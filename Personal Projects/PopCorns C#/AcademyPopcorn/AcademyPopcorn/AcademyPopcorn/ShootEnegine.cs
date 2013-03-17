using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShootEnegine : Engine
    {
        public ShootEnegine(IRenderer renderer, IUserInterface userInterface, int sleepTime) : base(renderer, userInterface, sleepTime)
        {
        }
        
        public void ShootPlayerRacket(){

            if (this.playerRacket is ShootingRacket)
            {
                ShootingRacket shotingRacket = this.playerRacket as ShootingRacket;
                shotingRacket.IsShooting = true;
            }
        }
    }
}