using System;

class Program
{
    static void Main()
    {
        int N = Int32.Parse(Console.ReadLine());
        string[] moves = new string[N];
        char[,] matrix3D = {
            {'R','B','R','R','B','R','R','B','R','R','B','R','R','B','R','R','B','R'},
            {'B','G','B','B','G','B','B','G','B','B','G','B','B','G','B','B','G','B'},
            {'R','B','R','R','B','R','R','B','R','R','B','R','R','B','R','R','B','R'}
        };
        for (int i = 0; i < N; i++)
        {
            moves[i] = Console.ReadLine();
        }
        for (int i = 0; i < N; i++)
        {
            char result = StartWalking(matrix3D, moves[i]);
            switch (result)
            {
                case 'G':
                    Console.WriteLine("GREEN");
                    break;
                case 'B':
                    Console.WriteLine("BLUE");
                    break;
                case 'R':
                    Console.WriteLine("RED");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
  
    private static char StartWalking(char[,] matrix3D, string moves)
    {
        int startHeight = 1;
        int startWidth = 1;
        int directionIndex = 0;
        char[] directions = {'R','B','L','T'}; // R,L,B,T

        for (int index = 0; index < moves.Length; index++)
        {
           // Moves
            if (moves[index] == 'W')
            {
                if (directions[directionIndex] == 'R')
                {
                    startWidth++;
                }
                if (directions[directionIndex] == 'L')
                {
                    startWidth--;
                }
                if (directions[directionIndex] == 'T')
                {
                    startHeight--;
                }
                if (directions[directionIndex] == 'B')
                {
                    startHeight++;
                }
            }

            if (moves[index] == 'R')
            {
                directionIndex++;
            }
            if (moves[index] == 'L')
            {
                directionIndex--;
            }
          // check
            if (directionIndex < 0)
            {
                directionIndex = directions.Length - 1;
            }
            if (directionIndex > directions.Length - 1)
            {
                directionIndex = 0;
            }
            if (startWidth > matrix3D.GetLength(1) - 1)
            {
                startWidth = 0;
            }

            if (startWidth < 0)
            {
                startWidth = matrix3D.GetLength(1) - 1;
            }

            if (startHeight > matrix3D.GetLength(0) - 1)
            {
                startHeight = 0;
            }

            if (startHeight < 0)
            {
                startHeight = matrix3D.GetLength(0) - 1;
            }
        }

        return matrix3D[startHeight,startWidth];
    }
}