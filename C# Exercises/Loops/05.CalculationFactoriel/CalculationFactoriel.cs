using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CalculationFactoriel
{
    static void Main(string[] args)
    {
        decimal N = Decimal.Parse(Console.ReadLine());
        decimal K = Decimal.Parse(Console.ReadLine());
        decimal factorielN = 1;
        decimal factorielK = 1;
        decimal factorielNK = 1;
        
        for (int i = 1; i <= K; i++)
        {
            factorielK *= i;
        }

        for (int i = 1; i <= N; i++)
        {
            factorielN *= i;
        }

        for (int i = 1 ; i < K - N; i++)
        {
            factorielNK *= i;
        }

        Console.WriteLine("Result is:{0}",(factorielK*factorielN)/factorielNK);
    }
}

