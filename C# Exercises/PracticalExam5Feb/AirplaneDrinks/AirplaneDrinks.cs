using System;
using System.Collections.Generic;
using System.Linq;

class AirplaneDrinks
{
    static void Main(string[] args)
    {
         List<uint> teaDrinkers = new List<uint>();
        uint passanegers = uint.Parse(Console.ReadLine());
        uint length = uint.Parse(Console.ReadLine());
        for (int i = 0; i < length; i++)
        {
            teaDrinkers.Add(uint.Parse(Console.ReadLine()));
        }
        
        StartServing(passanegers, teaDrinkers);
    }

    static void StartServing(uint passanegers, List<uint> teaDrinkers)
    {
        uint finalTime = 0;
        List<uint> coffeDrinkers = getDrinkers(passanegers, teaDrinkers);
        finalTime = Serving(teaDrinkers);
        finalTime += Serving(coffeDrinkers);
        Console.WriteLine(finalTime);
    }

    static List<uint> getDrinkers(uint passanegers, List<uint> teaDrinkers)
    {
        List<uint> coffeDrinkers = new List<uint>();
       
        for (uint index = 1; index < passanegers + 1; index++)
        {
            if (!teaDrinkers.Contains(index))
            {
                coffeDrinkers.Add(index);
            }
        }

        return coffeDrinkers;
    }

    static uint Serving(List<uint> drinkers)
    {
        //uint currentPassenger = 0;
        uint totalTime = 47; // fill the flask
        drinkers.Sort(); // sort  drinkers
        // server to specified pessengers
        int index = 0;
        while (index < drinkers.Count)
        {
            index += 7;
            if (drinkers.Count < index)
            {
                totalTime += drinkers[drinkers.Count - 1] * 2 +
                    (uint)(drinkers.Count % 7) * 4;
                break;
            }

            if (drinkers.Count == index)
            {
                totalTime += drinkers[index - 1] * 2 + 7 * 4;
                break;
            }

            if (drinkers.Count > index)
            {
                totalTime += drinkers[index - 1] * 2 + 7 * 4;
                totalTime += 47;
            }
        }
        /* for (int index = 0; index < drinkers.count; index++)
        {
        totaltime += drinkers[index] - currentpassenger + 4;
        currentpassenger = drinkers[index];
        go back and fill again
        if ((index + 1) % 7 == 0 && index + 1 == drinkers.count)
        {
        totaltime += currentpassenger;
        break;
        }
        if ((index + 1) % 7 == 0 && index != 0)
        {
        totaltime += currentpassenger; // return to machine
        totaltime += 47;    // fill the flask
        currentpassenger = 0;
        }
        } */

        // return to the machine
        /*  if (!(drinkers.Count % 7 == 0))
        {
        totalTime += currentPassenger;
        }*/

        return totalTime;
    }
}