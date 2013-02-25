using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheets
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxSum = Int32.Parse(Console.ReadLine());
            int currentSum = 0;
            List<string> used = new List<string>();
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("A0", 1024);
            dic.Add("A1", 512);
            dic.Add("A2", 256);
            dic.Add("A3", 128);
            dic.Add("A4", 64);
            dic.Add("A5", 32);
            dic.Add("A6", 16);
            dic.Add("A7", 8);
            dic.Add("A8", 4);
            dic.Add("A9", 2);
            dic.Add("A10", 1);
            foreach (var item in dic)
            {
                if ((currentSum + item.Value) <= maxSum)
                {
                    currentSum += item.Value;
                    used.Add(item.Key);
                }

                if (currentSum == maxSum)
                {
                    break;
                }
            }

            foreach (var item in dic)
            {
                if (!used.Contains(item.Key))
                {
                    Console.WriteLine(item.Key);
                }
                
            }
        }
    }
}
