using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<long, int> dic = new Dictionary<long, int>();
            int N = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                long number = long.Parse(Console.ReadLine());
                if (dic.ContainsKey(number))
                {
                    dic[number] += 1;
                }
                else
                {
                    dic.Add(number, 1);
                }

            }

            foreach (var item in dic)
            {
                if (item.Value % 2 != 0)
                {
                    Console.WriteLine(item.Key);
                }

            }


        }
    }
}
