using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ReadThreeIntergerNumbers
{
    static void Main(string[] args)
    {
       
        int[] numbers = new int[3];
        int sum =0;
        for (int index = 0; index < numbers.Length; index++)
			{
                Console.WriteLine("Enter number!");
			    if (Int32.TryParse(Console.ReadLine(),out numbers[index]))
	            {
                    sum = sum + numbers[index];
	            }
			}
        Console.WriteLine("The sum is:{0,3}",sum);
    }
}

