using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class InvalidNumberException
{
    static void Main(string[] args)
    {
        try
        {
            int numberReader = Int32.Parse(Console.ReadLine());
            if (numberReader < 0)
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine(Math.Sqrt(numberReader));

            }

        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid number!");
        }

        catch (OverflowException)
        {

            Console.WriteLine("Invalid number!");
        }
        finally
        {

            Console.WriteLine("Good bye!");
        }

        
    }
}

