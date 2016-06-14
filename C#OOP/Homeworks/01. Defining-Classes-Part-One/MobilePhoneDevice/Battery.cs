namespace MobilePhoneDevice
{
    using System;
    using System.Text;

    public class Battery
    {
        private string model;

        public Battery()
        {
        }

        public Battery(string model, int hoursIdle, int hoursTalk, BatteryType batteryType)
        {
            this.Model = model;
            this.HoursTalk = hoursTalk;
            this.HoursIdle = hoursIdle;
            this.BatteryType = batteryType;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Value of the {0} can not be null", this.model);
                }

                this.model = value;
            }
        }

        public int? HoursIdle { get; private set; }

        public int? HoursTalk { get; private set; }

        public BatteryType BatteryType { get; private set; }

        public override string ToString()
        {
            var info = new StringBuilder();

            info.AppendLine("--->Battery info<---");
            info.AppendLine(string.Format($"Model: {this.Model}"));
            info.AppendLine(string.Format($"Hours idle: {this.HoursIdle}"));
            info.AppendLine(string.Format($"Hours talk: {this.HoursTalk}"));
            info.Append(string.Format($"Type: {this.BatteryType}"));
            return info.ToString();
        }
    }
}
