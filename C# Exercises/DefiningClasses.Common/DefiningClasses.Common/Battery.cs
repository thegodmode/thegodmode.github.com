using System;
using System.Linq;

namespace DefiningClasses.Common
{
    public class Battery
    {
        private string model;
        private int? hoursIdle;
        private int? hoursTalk;
        private BatteryType batteryType;

        public Battery(string model = null, int? hoursIdle = null, int? hoursTalk = null, BatteryType batteryType = BatteryType.None)
        {
            if (hoursIdle<0|| hoursTalk<0)
            {
                throw new ArgumentException("Value of hours of talk and idle can not be less then zero");
            }
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.batteryType = batteryType;
        }

        public BatteryType BatteryType
        {
            get
            {
                return batteryType;
            }
            set
            {
                batteryType = value;
            }
        }

        public int? HoursTalk
        {
            get
            {
                return hoursTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("hours of talk cant be less then Zero");
                }
                hoursTalk = value;
            }
        }

        public int? HoursIdle
        {

            get
            {
                return hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hours of idle cant be less then Zero");
                }
                hoursIdle = value;
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

        public override string ToString()
        {
            
            return string.Format("  -Model: {0}\n  -HoursIdle: {1}h\n  -HoursTalk: {2}h\n  -BatteryType: {3}", model, hoursIdle, hoursTalk, batteryType);
        }
    }

    public enum BatteryType
    {
        None,
        Lilon,
        NiMH,
        NiCd
    }
}