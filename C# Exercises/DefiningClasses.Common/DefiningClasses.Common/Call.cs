using System;
using System.Linq;

namespace DefiningClasses.Common
{
    public class Call
    {
        private DateTime date;
        private DateTime time;
        private string dialedPhoneNumber;
        private int duration;
        
        public Call(string date, string time, string dialedPhoneNumber, int duration)
        {
            if (!DateTime.TryParse(date, out this.date) || !DateTime.TryParse(time, out this.time))
            {
                throw new ArgumentException("Input String is not in the correct format");
            }
          
            this.dialedPhoneNumber = dialedPhoneNumber;
            this.duration = duration;
        }

        public int Duration
        {
            get
            {
                return duration;
            }
        }

        public override string ToString()
        {
            return string.Format("Date: {0}\nTime: {1}\nDialedPhoneNumber: {2}\nDuration: {3}s", date.ToString("dd/MM/yyyy"), time.ToString("HH:mm:ss"), dialedPhoneNumber, duration);
        }



        
    }
}