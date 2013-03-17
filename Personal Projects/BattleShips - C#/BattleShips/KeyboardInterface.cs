using System;


namespace BattleShips
{
    public class KeyboardInterface : IUserInterface
    {
        private int x = 0;
        private int y = 0;

        public MatrixCoordinates ReadUserInput()
        {
            Console.Write("Enter X:");
            this.x = Int32.Parse(Console.ReadLine());
            Console.Write("Enter Y:");
            this.y = Int32.Parse(Console.ReadLine());
            return new MatrixCoordinates(this.x, this.y);
        }
    }
}