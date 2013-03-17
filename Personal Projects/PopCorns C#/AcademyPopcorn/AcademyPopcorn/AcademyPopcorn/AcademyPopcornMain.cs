using System;
using System.Linq;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;
            
            for (int i = startCol; i < endCol; i++)
            {
                //ExplodingBlock currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));
                GiftBlock giftBlock = new GiftBlock(new MatrixCoords(startRow + 1, i));
                // engine.AddObject(currBlock);
                engine.AddObject(giftBlock);
            }
            // upper wall
            for (int col = 0; col < WorldCols; col++)
            {
                UnpassableBlocks block = new UnpassableBlocks(new MatrixCoords(0, col));
                engine.AddObject(block);
            }

            // left and right wall 
            for (int row = 1; row < WorldRows; row++)
            {
                UnpassableBlocks leftblock = new UnpassableBlocks(new MatrixCoords(row, 0));
                UnpassableBlocks rIghtblock = new UnpassableBlocks(new MatrixCoords(row, WorldCols - 1));
                engine.AddObject(leftblock);
                engine.AddObject(rIghtblock);
            }

            UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            Racket theRacket1 = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength + 3);
            engine.AddObject(theRacket);
            engine.AddObject(theRacket1);
            //    Gift gift = new Gift(new MatrixCoords(0, 5));
            //    engine.AddObject(gift);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            ShootEnegine gameEngine = new ShootEnegine(renderer, keyboard, 200);
            
            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}