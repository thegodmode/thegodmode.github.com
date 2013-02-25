using System;
using System.Linq;
using Common.Classes;

namespace TestMatrix
{
    class TestMatrix
    {
        static void Main(string[] args)
        {
            int[,] arr1 = {
                {1,2,3},
                {4,5,6}
                
            };

            int[,] arr2 = {
                {7,8},
                {9,10},
                {11,12},
            };

            double[,] arr3 = {
                {1.5,2.5,3.7},
                {4,5,6}
                
            };

            double[,] arr4 = {
                {7,8},
                {9,10},
                {11,12},
            };

            //string[,] arr5 = new string[20,20];

           /* int[,] arr2 = {    check true and false operators
                {0,0},
                {0,0},
                {0,0},
            };
            */
            
            Matrix<int> matrix = new Matrix<int>(arr1);
            Matrix<int> matrix1 = new Matrix<int>(arr2);
            Matrix<double> matrix2 = new Matrix<double>(arr3);
            Matrix<double> matrix3 = new Matrix<double>(arr4);
           // Matrix<string> matrix4 = new Matrix<string>(arr5);
            //matrix.printMatrix();
            matrix = matrix * matrix1;
            matrix2 = matrix2 * matrix3;
            if (matrix)
            {
                matrix.PrintMatrix();
                matrix2.PrintMatrix();
            }
            else
            {
                Console.WriteLine("Matrix has 0 Value");
            }
           
        }
    }
}