using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Expression
{
    class MathExpression
    {
        static void Main(string[] args)
        {
            double N = double.Parse(Console.ReadLine());
            double M = double.Parse(Console.ReadLine());
            double P = double.Parse(Console.ReadLine());
            checked
            {
                double result = ((N * N + (1 / (M * P)) + 1337) / (N - 128.523123123 * P)) + Math.Sin((int)M % 180);
                Console.WriteLine("{0:0.000000}", result);
            }
            
        }
    }
}
