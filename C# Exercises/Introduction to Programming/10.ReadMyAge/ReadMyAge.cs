using System;

class ReadMyAge
{
    static void Main(string[] args)
    {
        int myAge = 0;
        bool success = false;
        do
        {
            Console.WriteLine("Enter your age!");
            success = Int32.TryParse(Console.ReadLine(), out myAge);
            if (success)
            {
                Console.WriteLine("Your age after ten years are: {0}", myAge + 10);
            }
            else
            {
               Console.WriteLine("Uncorrect type of data!");
            }
        } while (!success);
        Console.CursorLeft = 5;
           
       
    }
}

