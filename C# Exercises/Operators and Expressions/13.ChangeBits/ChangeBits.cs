using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ChangeBits
{
    static void Main(string[] args)
    {
        int number = 41943047; // given number
        int[] positions = new int[] { 0, 1, 2, 23, 24, 25 }; // array for store positions
        int[] values = new int[6]; // array for store values
        int mask = 1; //mask
        int temp = 0; // variable that help to change values
        //Store bits value under certain positions
        for (int index = 0; index < positions.Length; index++, mask = 1)
        {
            mask = mask << positions[index];
            values[index] = (number & mask) >> positions[index];
        }
        //exchange values in array
        for (int begin = 0; begin < values.Length / 2; begin++)
        {
            temp = values[begin];
            values[begin] = values[begin + 3];
            values[begin + 3] = temp;
        }
        // Replace the new bits value
        for (int index = 0; index < positions.Length; index++,mask=1)
        {
            mask = mask << positions[index];
            if (values[index] == 1)
            {
                number = number | mask;
            }
            else
            {
                number = number & ~(mask);
            }
        }

        Console.WriteLine(number);

    }
}

