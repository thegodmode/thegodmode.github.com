using System;
using DefiningClasses.Common;

namespace CallHistoryTest
{
    class CallHistoryTest
    {
        static void Main(string[] args)
        {
             // GSM 1
             GSM nokia = new GSM("Nokia", "Nokia", 15, "Nokia");
             // Add Calls 
            Call c1 = new Call("11/14/2001","14:27:36","+123456",900);
            Call c2 = new Call("11/19/2001","14:56:36","+359883442324",800);
            Call c3 = new Call("11/19/2001","12:27:36","+359883442324",800);
            nokia.AddCall(c1);
            nokia.AddCall(c2);
            nokia.AddCall(c3);
            // Display Calls Info
            nokia.PrintCallHistory();
            // Display Total Price of All Calls
            Console.WriteLine("Total Price of All Calls:{0:C2}", nokia.CallsTotalPrice(0.37m));
            // Remove Call
            nokia.RemoveCall(c1);
            Console.WriteLine("Total Price of All Calls:{0:C2}", nokia.CallsTotalPrice(0.37m));
            // Clear Call History
            nokia.RemoveAllCalls();
            nokia.PrintCallHistory();
             


        }
    }
}