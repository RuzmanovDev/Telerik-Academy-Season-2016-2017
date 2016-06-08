namespace MobilePhoneDevice
{
    using System;

    public class Call
    {
        public const decimal PricePerMinute = 0.37M;

        public Call(DateTime date, int duration, string phone)
        {
            this.Date = date;
            this.CallDuration = duration;
            this.DialedPhoneNumber = phone;
        }

        public DateTime Date { get; private set; }

        public int CallDuration { get; private set; }

        public string DialedPhoneNumber { get; private set; }

        public override string ToString()
        {
            return string.Format($"Dialed phone {this.DialedPhoneNumber} Date: {this.Date} Call duration: {this.CallDuration}");
        }
    }
}
