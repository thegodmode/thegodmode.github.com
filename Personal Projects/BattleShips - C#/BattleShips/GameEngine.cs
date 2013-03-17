using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    class GameEngine
    {
        private Field playerField;
        private Field gameField;
        private List<Ship> playerShips;
        private List<Ship> computerShips;
        IUserInterface keyboard;
        IRenderer renderer;

        public GameEngine(Field playerField, List<Ship> playerShips, Field gameField, List<Ship> computerShips, IUserInterface keyboard, IRenderer renderer)
        {
            this.playerField = playerField;
            this.gameField = gameField;
            this.playerShips = playerShips;
            this.computerShips = computerShips;
            this.keyboard = keyboard;
            this.renderer = renderer;
        }

        public void Run()
        {
            // add  playership in player field
            foreach (var item in playerShips)
            {
                playerField.AddShip(item);
            }

            // add fields for rendering
            renderer.AddForRendering(playerField);
            renderer.AddForRendering(gameField);

            // render fields on console
            renderer.RenderAll();

            // clear renderer
            renderer.ClearQueue();
            while (playerShips.Count != 0 && computerShips.Count != 0)
            {
                // read player coordinates
                MatrixCoordinates shot = keyboard.ReadUserInput();
                MatrixCoordinates robotShot = Robot.GenerateShot();
                if (shot.Row > 10 || shot.Row < 1)
                {
                    throw new ShotException("Row must be from [1 to 10]");
                }

                if (shot.Col > 20 || shot.Col < 1)
                {
                    throw new ShotException("Col must be from [1 to 20]");
                }
                
                // add shot as unsuccessful
                gameField.AddUnSuccessfulShot(shot);
                playerField.AddUnSuccessfulShot(robotShot);

                // check if computer ship is Hit
                foreach (var item in computerShips)
                {
                    if (item.IsHit(shot))
                    {
                        gameField.AddSuccessfulShot(shot);
                        break;
                    }
                }

                // check if player ship is Hit
                foreach (var item in playerShips)
                {
                    if (item.IsHit(shot))
                    {
                        playerField.AddSuccessfulShot(shot);
                        break;
                    }
                }
                renderer.AddForRendering(playerField);
                renderer.AddForRendering(gameField);
                renderer.RenderAll();
                renderer.ClearQueue();
                computerShips.RemoveAll(ship => ship.IsDestroyed);
                playerShips.RemoveAll(ship => ship.IsDestroyed);
            }

            if (computerShips.Count == 0)
            {
                Console.WriteLine("Congratssss You Win!");
            }
            else
            {
                Console.WriteLine("You LOST!");
            }
        }
    }
}