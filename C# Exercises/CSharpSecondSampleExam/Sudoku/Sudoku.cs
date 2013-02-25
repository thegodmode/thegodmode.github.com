using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    class Sudoku
    {
        static void Main(string[] args)
        {
            byte[,] sudoku = new byte[9, 9];
            byte emptyCells = 0;
            emptyCells = ReadSudoku(sudoku, emptyCells);
            SolveSudoku(sudoku, emptyCells);

        }

        static void SolveSudoku(byte[,] sudoku, byte emptyCell)
        {
            bool solutionFound = false;
            emptyCell = SolveWithoutRecursion(sudoku, emptyCell);
            if (emptyCell == 0)
            {
                PrintSudoku(sudoku);
            }
            else
            {
                solutionFound = SolveWithRecursion(sudoku, emptyCell, solutionFound);
                if (solutionFound)
                {
                    PrintSudoku(sudoku);
                }
                else
                {
                    Console.WriteLine("No solution found!");
                }

            }

        }
        static bool SolveWithRecursion(byte[,] sudoku, byte emptyCell, bool solutionFound)
        {
            if (emptyCell == 0)
            {
                return true;
            }
            emptyCell--;
            for (int row = 0; row < sudoku.GetLength(0); row++)
            {
                for (int col = 0; col < sudoku.GetLength(1); col++)
                {
                    if (sudoku[row, col] == 0)
                    {
                        List<byte> candidates = GetCandidates(sudoku, (byte)row, (byte)col);
                        do
                        {
                            if (FillCell(sudoku, (byte)row, (byte)col, candidates))
                            {

                                solutionFound = SolveWithRecursion(sudoku, emptyCell, solutionFound);
                                if (solutionFound)
                                {
                                    return true;
                                }
                                emptyCell++;
                            }
                            else
                            {
                                sudoku[row, col] = 0;
                                return false;
                            }
                        } while (true);
                    }
                }
            }

            return true;
        }
        static bool FillCell(byte[,] sudoku, byte row, byte col, List<byte> candidates)
        {
            if (candidates.Count > 1)
            {
                byte candidate = GetRandomCandidate(candidates.Count, candidates);
                sudoku[row, col] = candidate;
                candidates.Remove(candidate);
                return true;
            }
            else if (candidates.Count == 1)
            {
                sudoku[row, col] = candidates[0];
                candidates.Remove(candidates[0]);
                return true;
            }
            else
            {
                return false;
            }
        }
        static byte GetRandomCandidate(int count, List<byte> candidates)
        {
            Random rn = new Random();
            int random = rn.Next(0, count);
            return candidates[random];
        }
        static byte SolveWithoutRecursion(byte[,] sudoku, byte emptyCell)
        {
            bool isSuccessful = false;

            do
            {
                isSuccessful = false;
                for (int row = 0; row < sudoku.GetLength(0); row++)
                {

                    for (int col = 0; col < sudoku.GetLength(1); col++)
                    {
                        if (sudoku[row, col] == 0)
                        {
                            if (TryToFillCell(sudoku, (byte)row, (byte)col))
                            {
                                emptyCell--;
                                isSuccessful = true;
                            }
                        }
                    }
                }
            } while (isSuccessful);

            return emptyCell;
        }
        static List<byte> GetCandidates(byte[,] sudoku, byte row, byte col)
        {
            List<byte> possibleCandidates = new List<byte> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //check rows;
            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                if (sudoku[i, col] != 0)
                {
                    possibleCandidates.Remove(sudoku[i, col]);
                }

            }
            // check cols
            for (int i = 0; i < sudoku.GetLength(1); i++)
            {
                if (sudoku[row, i] != 0)
                {
                    possibleCandidates.Remove(sudoku[row, i]);
                }
            }

            // check sub matrix
            int topLeftRow = row - row % 3;
            int topLeftCol = col - col % 3;
            for (int r = topLeftRow; r < topLeftRow + 3; r++)
            {
                for (int c = topLeftCol; c < topLeftCol + 3; c++)
                {
                    if (sudoku[r, c] != 0)
                    {
                        possibleCandidates.Remove(sudoku[r, c]);
                    }
                }
            }

            return possibleCandidates;

        }
        static bool TryToFillCell(byte[,] sudoku, byte row, byte col)
        {
            List<byte> candidates = GetCandidates(sudoku, row, col);
            if (candidates.Count == 1)
            {
                sudoku[row, col] = candidates[0];
                return true;
            }
            else
            {
                return false;
            }

        }
        static byte ReadSudoku(byte[,] sudoku, byte emptyCells)
        {

            for (int row = 0; row < sudoku.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < sudoku.GetLength(1); col++)
                {
                    if (line[col] == '-')
                    {
                        sudoku[row, col] = 0;
                        emptyCells++;
                    }
                    else
                    {
                        sudoku[row, col] = (byte)(line[col] - '0');

                    }

                }

            }

            return emptyCells;
        }
        static void PrintSudoku(byte[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}