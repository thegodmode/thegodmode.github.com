using System;
using System.Linq;



class CalculateWorksDays
{
    static void Main(string[] args)
    {
        DateTime myDate = new DateTime(2012, 12, 30);
        Console.WriteLine(CalculateWorkDays(myDate));
    }

    static int CalculateWorkDays(DateTime givenDate)
    {
        DateTime now = DateTime.Now.Date;
        int counter = 0;
        DateTime[] holidays = { new DateTime(2012, 11, 19), new DateTime(2012, 11, 26), new DateTime(2012, 11, 28), new DateTime(2012, 12, 11), new DateTime(2012, 11, 18), new DateTime(2012, 12, 26) };
        DateTime[] workdays = { new DateTime(2012, 11, 10), new DateTime(2012, 11, 11), };
        if (now > givenDate)
        {
            Console.WriteLine("The Input Data must be Later then today!");
            return -1;
        }
        else
        {
            while (now <= givenDate)
            {
                if ((now.DayOfWeek.ToString().Equals("Saturday")) || (now.DayOfWeek.ToString().Equals("Sunday")))
                {
                    for (int i = 0; i < workdays.Length; i++)
                    {
                        if (workdays[i] == now)
                        {
                            counter++;
                            break;
                        }
                    }
                    
                }
                else
                {
                    bool isHoliday = false;
                    for (int index = 0; index < holidays.Length; index++)
                    {
                        if (holidays[index] == now)
                        {
                            isHoliday = true;
                            break;
                        }
                    }
                    if (!isHoliday)
                    {
                        counter++;

                    }
                    
                };
                now = now.AddDays(1);
            }
            return counter;
        }

    }
}

