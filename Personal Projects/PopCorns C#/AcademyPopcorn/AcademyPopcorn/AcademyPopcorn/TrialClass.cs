using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrialClass : GameObject
    {
        int lifetime;

        public TrialClass(MatrixCoords topLeft, int lifetime) : base(topLeft, new char[,]{{'.'}})
        {
            this.Lifetime = lifetime;
        }
        
        public int Lifetime
        {
            private get
            {
                return lifetime;
            }
            set
            {
                if (lifetime < 0)
                {
                    throw new ArgumentException("LifeTime must be positive integer");
                }
                lifetime = value;
            }
        }

        private void UpdateLifeTime()
        {
            if (this.Lifetime > 0)
            {
                this.Lifetime -= 1;
            }
            else
            {
                this.IsDestroyed = true;
            }
        }

        public override void Update()
        {
            this.UpdateLifeTime();
        }
    }
}