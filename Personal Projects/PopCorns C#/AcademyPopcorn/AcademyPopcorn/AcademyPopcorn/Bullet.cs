using System;

namespace AcademyPopcorn
{
    class Bullet : MovingObject
    {
        public new const string CollisionGroupString = "bullet";

        public Bullet(int row, int col) : base(new MatrixCoords(row,col), new char[,]{{'|'}}, new MatrixCoords(-1,0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return Bullet.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}