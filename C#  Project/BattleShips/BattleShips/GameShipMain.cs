using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    class GameShipMain
    {
        static GameEngine Initialize()
        {
            Field field = new Field();
            Field gameField = new Field();
            List<Ship> playerShips = new List<Ship>();
            List<Ship> computerShips = new List<Ship>();
            IUserInterface keyboard = new KeyboardInterface();
            IRenderer renderer = new ConsoleRenderer();
            ShipGenerator.Generate(5, playerShips);
            ShipGenerator.Generate(1, computerShips);
            GameEngine engine = new GameEngine(field, playerShips, gameField, computerShips, keyboard, renderer);
            return engine;
        }

        static void Main(string[] args)
        {
            GameEngine engine = Initialize();
            
            try
            {
                engine.Run();
            }
            catch (ShotException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
