using System;
using System.Linq;

namespace BattleShips
{
    public class Field : IRendable
    { //[10,20];
        private char[,] field = {
            {' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' '},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
        };
        
        public void Draw()
        {
            for (int row = 0; row < this.field.GetLength(0); row++)
            {
                for (int col = 0; col < this.field.GetLength(1); col++)
                {
                    if (field[row,col] != '_' && field[row,col] != 'x' && field[row,col] != '|' && field[row,col] != ' ')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (field[row,col] == 'o')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (field[row, col] == 'x')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(field[row,col]);
                }

                Console.WriteLine();
            }
        }

        private void InsertHorizontalShip(int length, MatrixCoordinates topLeft, char symbol)
        {
            int row = topLeft.Row;
            int col = topLeft.Col * 2 - 1;
            for (int i = 0; i < length; i++)
            {
                this.field[row,col] = symbol ;
                while (field[row,col] != '_')
                {
                    col++;
                }
            }
        }

        private void InsertVerticalShip(int length, MatrixCoordinates topLeft, char symbol)
        {
            int row = topLeft.Row;
            int col = topLeft.Col * 2 - 1;
            for (int i = 0; i < length; i++)
            {
                this.field[row,col] = symbol;
                while (field[row,col] != '_')
                {
                    row++;
                }
            }
        }
       
        public void AddShip(IShipable ship)
        {
            switch (ship.GetOrientation())
            {
                case Orientation.Horizontal:
                    InsertHorizontalShip(ship.GetShipLength(), ship.GetTopLeftPosition(), ship.GetSymbol());
                    break;
                case Orientation.Vertical:
                    InsertVerticalShip(ship.GetShipLength(), ship.GetTopLeftPosition(), ship.GetSymbol());
                    break;
                default:
                    break;
            }
        }

        public void AddSuccessfulShot(MatrixCoordinates shot)
        {
            int row = shot.Row;
            int col = shot.Col * 2 - 1;
            field[row, col] = 'o';
        }

        public void AddUnSuccessfulShot(MatrixCoordinates shot)
        {
            int row = shot.Row;
            int col = shot.Col * 2 - 1;
            field[row, col] = 'x';
        }
    }
}