using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Position
{
    public int row;
    public int col;
    public List<char> pathDirections = new List<char>();
    public Position(int row, int col, List<char> directions, char direction)
    {
        this.row = row;
        this.col = col;
        this.pathDirections.AddRange(directions);
        this.pathDirections.Add(direction);
    }
}
class LargestConnectingAreaToCells
{
    static char[,] matrix = 
                            {
                                 {' ',' ',' ',' '},
                                 {'x','x',' ',' '},
                                 {' ',' ',' ',' '},
                                 {' ',' ',' ',' '},
                                 {' ',' ',' ','e'}
                           };
    
    static Queue<Position> queue = new Queue<Position>();
   
    static void Main(string[] args)
    {
        Position start = CreateStartPosition();
        queue.Enqueue(start);
        List<char> path = FindShortestPath();
        Print(path);
    }

    static Position CreateStartPosition(){
              
        Position start = new Position(0, 0, new List<char>(), 'S');
        return start;
    }
    static List<char> FindShortestPath()
    {

        do
        {
            Position newPosition = queue.Dequeue();
            if (newPosition.row < 0 || newPosition.col < 0
                || newPosition.row >= matrix.GetLength(0)
                || newPosition.col >= matrix.GetLength(1))
            {
                continue;
            }
            if (matrix[newPosition.row, newPosition.col] == 'e')
            {
                return newPosition.pathDirections;
            }
            if (matrix[newPosition.row, newPosition.col] == ' ')
            {
                matrix[newPosition.row, newPosition.col] = 's';
                queue.Enqueue(new Position(newPosition.row + 1, newPosition.col, newPosition.pathDirections, 'D'));
                queue.Enqueue(new Position(newPosition.row - 1, newPosition.col, newPosition.pathDirections, 'U'));
                queue.Enqueue(new Position(newPosition.row, newPosition.col + 1, newPosition.pathDirections, 'R'));
                queue.Enqueue(new Position(newPosition.row, newPosition.col - 1, newPosition.pathDirections, 'L'));

            }


        } while (queue.Count > 0);

        return new List<char>();
    }

    static void Print(List<char> path)
    {
        if (path.Count==0)
        {
            Console.WriteLine("There are no ways from the matrix");
        }
        else
        {
            Console.WriteLine("The shortest way is:");
            foreach (var direction in path)
            {
                if (direction == 'S')
                {
                    continue;
                }

                Console.Write(direction + " ");
            }
            Console.WriteLine();
        }
    }
}

