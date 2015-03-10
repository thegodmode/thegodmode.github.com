using System;
using System.Collections.Generic;
using System.Linq;
using DefiningClasses.Common;

namespace TestGSM
{
    class TestGSM
    {
        static void Main(string[] args)
        {
            
            // GSM 1
            BatteryType type = BatteryType.Lilon;
            GSM nokia = new GSM("Nokia", "Nokia", 15,"Nokia");
            nokia.Battery = new Battery("QI-HTC", 2000, 200, type);
            nokia.Display=  new Display(12, 12, 256000);
            
            // GSM 2
            BatteryType type1 = BatteryType.NiCd;
            GSM samsung = new GSM("Samsung", "Samsung", 1000, "Samsung");
            samsung.Battery = new Battery("VP-DSDS", 11, 12, type);
            samsung.Display = new Display(12, 11, 160000000);


            // GSM 3
            BatteryType type2 = BatteryType.Lilon;
            GSM iphoneS2 = new GSM("Apple", "Apple", 1500, "Apple");
            iphoneS2.Battery = new Battery("VP-das", 12, 14, type);
            iphoneS2.Display = new Display(12, 11, 160000000);

            // Add in array
            List<GSM> array = new List<GSM>()
            {
                nokia,samsung,iphoneS2

            };

            // Test telephones

            foreach (var item in array)
            {
                Console.WriteLine(item);
                Console.WriteLine(new String('-',50));
            }

            //Test Iphone4S
            Console.WriteLine(GSM.IPhone4S);
           
            
        }
    }
}
