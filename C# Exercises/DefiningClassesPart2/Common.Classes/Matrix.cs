using System;
using System.Linq;

namespace Common.Classes
{
    public class Matrix<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private readonly T[,] matrix;
        private readonly int rowLength;
        private readonly int colLength;

        public Matrix(T[,] matrix)
        {
            this.matrix = matrix;
            rowLength = matrix.GetLength(0);
            colLength = matrix.GetLength(1);
        }

        public int RowLength
        {
            get
            {
                return rowLength;
            }
        }

        public int ColLength
        {
            get
            {
                return colLength;
            }
        }

        public T this [int row, int col]
        {
            get 
            {
                if (row < 0 || col < 0)
                {
                    throw new ArgumentException("Row and Col must be positive values");
                }

                if (row >= matrix.Length || col >= matrix.Length)
                {
                    throw new ArgumentOutOfRangeException("Argument out of Range");
                }

                return matrix[row,col];
            }

            set
            {
                if (row < 0 || col < 0)
                {
                    throw new ArgumentException("Row and Col must be positive values");
                }

                if (row >= matrix.Length || col >= matrix.Length)
                {
                    throw new ArgumentOutOfRangeException("Argument out of Range");
                }

                matrix[row,col] = value;
            }
        }

        public static Matrix<T> operator -(Matrix<T> fraction1, Matrix<T> fraction2)
        {
            if ((fraction1.rowLength != fraction2.rowLength) || (fraction1.colLength != fraction2.colLength))
            {
                throw new ArgumentException("The matrix must hava same dimensions");
            }
            Matrix<T> temp = new Matrix<T>(new T[fraction1.rowLength,fraction1.colLength]);
            
            for (int r = 0; r < fraction1.rowLength; r++)
            {
                for (int c = 0; c < fraction1.colLength; c++)
                {
                    temp[r,c] = (dynamic)fraction1[r,c] - (dynamic)fraction2[r,c];
                }
            }
            return temp;
        }

        public static Matrix<T> operator +(Matrix<T> fraction1, Matrix<T> fraction2)
        {
            if ((fraction1.rowLength != fraction2.rowLength) || (fraction1.colLength != fraction2.colLength))
            {
                throw new ArgumentException("The matrix must hava same dimensions");
            }
            Matrix<T> temp = new Matrix<T>(new T[fraction1.rowLength,fraction1.colLength]);

            for (int r = 0; r < fraction1.rowLength; r++)
            {
                for (int c = 0; c < fraction1.colLength; c++)
                {
                    temp[r,c] = (dynamic)fraction1[r,c] + (dynamic)fraction2[r,c];
                }
            }
            return temp;
        }

        public static Matrix<T> operator *(Matrix<T> fraction1, Matrix<T> fraction2)
        {
            if ((fraction1.colLength != fraction2.rowLength))
            {
                throw new ArgumentException("The matrix1 col legth must be equal to matrix2 row length");
            }
            Matrix<T> temp = new Matrix<T>(new T[fraction1.rowLength,fraction2.colLength]);

            // matrix1: m x n   matrix2: n x p  == > temp m x p
            for (int m = 0; m < fraction1.rowLength; m++)
            {
                for (int p = 0; p < fraction2.colLength; p++)
                {
                    for (int n = 0; n < fraction1.colLength; n++)
                    {
                        temp[m,p] += (dynamic)fraction1[m,n] * (dynamic)fraction2[n,p];
                    }
                }
            }
            return temp;
        }

        public static bool operator true(Matrix<T> x)
        {
            for (int r = 0; r < x.RowLength; r++)
            {
                for (int c = 0; c < x.ColLength; c++)
                {
                    if ((dynamic)x[r,c] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> x)
        {
            for (int r = 0; r < x.RowLength; r++)
            {
                for (int c = 0; c < x.ColLength; c++)
                {
                    if ((dynamic)x[r,c] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void PrintMatrix()
        {
            for (int r = 0; r < this.rowLength; r++)
            {
                for (int c = 0; c < this.colLength; c++)
                {
                    Console.Write("{0} ", this.matrix[r,c]);
                }
                
                Console.WriteLine();
            }
        }
    }
}