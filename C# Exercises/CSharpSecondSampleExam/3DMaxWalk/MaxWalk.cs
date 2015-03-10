using System;
using System.Linq;

class Cell
{
    sbyte dimension = 0;
    sbyte row = 0;
    sbyte col = 0;
    short value = 0;
   
    public short Value
    {
        get
        {
            return this.value;
        }
        set
        {
            this.value = value;
        }
    }

    public sbyte Col
    {
        get
        {
            return col;
        }
        set
        {
            col = value;
        }
    }

    public sbyte Row
    {
        get
        {
            return row;
        }
        set
        {
            row = value;
        }
    }

    public sbyte Dimension
    {
        get
        {
            return dimension;
        }
        set
        {
            dimension = value;
        }
    }

    public Cell(sbyte dim, sbyte row, sbyte col, short value)
    {
        this.dimension = dim;
        this.col = col;
        this.row = row;
        this.value = value;
    }
}

class MaxWalk
{
    static void Main(string[] args)
    {
        short[,,] matrix3D = Read3DMatrix();

        bool[,,] isVisited = GenerateMatrix(matrix3D);

        int finalResult = 0;

        finalResult = StartWalking(matrix3D, isVisited);
        Console.WriteLine(finalResult);
    }

    static bool[,,] GenerateMatrix(short[,,] matrix)
    {
        bool[,,] newMatrix = new bool[matrix.GetLength(0),matrix.GetLength(1),matrix.GetLength(2)];
        for (int d = 0; d < newMatrix.GetLength(0); d++)
        {
            for (int h = 0; h < newMatrix.GetLength(1); h++)
            {
                for (int w = 0; w < newMatrix.GetLength(2); w++)
                {
                    newMatrix[d,h,w] = false;
                }
            }
        }

        return newMatrix;
    }

    static short[,,] Read3DMatrix()
    {
        string inputNumbers = Console.ReadLine();
        string[] numbers = inputNumbers.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
        byte width = Byte.Parse(numbers[0]);
        byte height = Byte.Parse(numbers[1]);
        byte depth = Byte.Parse(numbers[2]);
        short[,,] matrix3D = new short[depth,height,width];

        for (int h = 0; h < height; h++)
        {
            int argsIndex = 0;
            string line = Console.ReadLine();
            string[] args = line.Split(new char[]{' ','|'}, StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < depth; d++)
            {
                for (int w = 0; w < width; w++)
                {
                    matrix3D[d,h,w] = short.Parse(args[argsIndex++]);
                }
            }
        }

        return matrix3D;
    }

    static int StartWalking(short[,,] matrix, bool[,,] isVisited)
    {
        sbyte startDimension = (sbyte)(matrix.GetLength(0) / 2);
        sbyte startRow = (sbyte)(matrix.GetLength(1) / 2);
        sbyte startCol = (sbyte)(matrix.GetLength(2) / 2);
        isVisited[startDimension,startRow,startCol] = true;
        Cell currentPosition = new Cell(startDimension, startRow, startCol, matrix[startDimension,startRow,startCol]);
        int sum = currentPosition.Value;

        while (true)
        {
            Cell candidate = GetMaxCell(matrix, currentPosition);
            if (candidate.Col == -1 || candidate.Row == -1 || candidate.Dimension == -1)
            {
                break;
            }
            else if (isVisited[candidate.Dimension,candidate.Row,candidate.Col] == true)
            {
                break;
            }
            else
            {
                currentPosition = candidate;
                isVisited[candidate.Dimension,candidate.Row,candidate.Col] = true;
                sum += candidate.Value;
            }
        }

        return sum;
    }

    static Cell GetMaxCell(short[,,] matrix, Cell currentPosition)
    {
        short maxValue = short.MinValue;
        byte i = 0;
        sbyte depth = -1;
        sbyte row = -1;
        sbyte col = -1;

        // get max Col value 
        for (; i < matrix.GetLength(2); i++)
        {
            if (i == currentPosition.Col)
            {
                continue;
            }
            if (maxValue == matrix[currentPosition.Dimension,currentPosition.Row,i])
            {
                depth = -1;
                row = -1;
                col = -1;
            }
            if (matrix[currentPosition.Dimension,currentPosition.Row,i] > maxValue)
            {
                maxValue = matrix[currentPosition.Dimension,currentPosition.Row,i];
                depth = currentPosition.Dimension;
                row = currentPosition.Row;
                col = (sbyte)i;
            }
        }
        
        // get max Row value 
        for (i = 0; i < matrix.GetLength(1); i++)
        {
            if (i == currentPosition.Row)
            {
                continue;
            }
            if (maxValue == matrix[currentPosition.Dimension,i,currentPosition.Col])
            {
                depth = -1;
                row = -1;
                col = -1;
            }
            if (matrix[currentPosition.Dimension,i,currentPosition.Col] > maxValue)
            {
                maxValue = matrix[currentPosition.Dimension,i,currentPosition.Col];
                depth = currentPosition.Dimension;
                row = (sbyte)i;
                col = currentPosition.Col;
            }
        }

        // get Max Dimension value
        for (i = 0; i < matrix.GetLength(0); i++)
        {
            if (i == currentPosition.Dimension)
            {
                continue;
            }
            if (maxValue == matrix[i,currentPosition.Row,currentPosition.Col])
            {
                depth = -1;
                row = -1;
                col = -1;
            }
            if (matrix[i,currentPosition.Row,currentPosition.Col] > maxValue)
            {
                maxValue = matrix[i,currentPosition.Row,currentPosition.Col];
                depth = (sbyte)i;
                row = currentPosition.Row;
                col = currentPosition.Col;
            }
        }
        return new Cell(depth, row, col, maxValue);
    }
}