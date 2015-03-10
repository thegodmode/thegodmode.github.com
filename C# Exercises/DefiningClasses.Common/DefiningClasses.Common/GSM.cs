using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses.Common
{
    public class GSM
    {
        private string model;
        private string manufacturer;
        private int? price;
        private string owner;
        private Battery battery;
        private Display display;
        private static GSM iPhone4S;
        private List<Call> callHistory;

        public GSM(string model, string manufacturer, int? price= null, string owner=null)
        {
            if (price < 0)
            {
                throw new ArgumentException("GSM price must be postive value");
            }
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = new Battery();
            this.display = new Display();
            this.callHistory = new List<Call>();
        }

        static GSM()
        {
            iPhone4S = new GSM("Iphone 4S", "Apple", 800, "Apple");
            IPhone4S.Battery = new Battery("1432mAh", 200, 14, BatteryType.Lilon);
            IPhone4S.Display = new Display(640, 960, 16000000);
            iPhone4S.AddCall(new Call(DateTime.Now.ToString("MM/dd/yyyy"),DateTime.Now.ToString("HH:mm:ss"),"+359883475433",300));
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }
             
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = value;
            }
        }

        public string Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }

        public int? Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("GSM price must be postive value");
                }
                price = value;
            }
        }

        public Display Display
        {
            get
            {
                return display;
            }
            set
            {
                display = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return battery;
            }
            set
            {
                battery = value;
            }
        }

        public override string ToString()
        {
            string batteryFormat = battery.ToString();
            string displayFormat = display.ToString();
            return string.Format("GSM:\n -Model: {0}\n -Manufacturer: {1}\n -Price: {2:C0}\n -Owner: {3}\n -Battery:\n{4}\n -Display:\n{5}", model, manufacturer, price, owner, batteryFormat, displayFormat);
        }

        public void AddCall(Call newCall)
        {
            callHistory.Add(newCall);
        }

        public void RemoveCall(Call deleteCall)
        {
            callHistory.Remove(deleteCall);
        }

        public void RemoveAllCalls()
        {
            callHistory.Clear();
        }

        public void PrintCallHistory()
        {
            if (callHistory.Count == 0)
            {
                Console.WriteLine("Call History is Empty");
                return;
            }
            foreach (var item in callHistory)
            {
                Console.WriteLine(item);
                Console.WriteLine(new String('-', 50));
            }
        }

        public decimal CallsTotalPrice(decimal taxPerCall)
        {
            decimal totalSum = 0;
            foreach (var call in callHistory)
            {
                totalSum += ((decimal)call.Duration / 60) * taxPerCall;
            }

            return totalSum;
        }
    }
}