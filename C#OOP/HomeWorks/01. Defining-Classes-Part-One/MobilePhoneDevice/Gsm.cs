namespace MobilePhoneDevice
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gsm
    {
        public static Gsm iPhone4S;

        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;

        // I use IList for greater code flexability
        private IList<Call> listOfCalls;

        static Gsm()
        {
            iPhone4S = new Gsm(
                "Iphone 4s",
                "Apple",
                9999999999,
                "Pesho",
                new Battery("AppleBat", 10, 10, BatteryType.LiIon),
                new Display(6, 2));
        }

        public Gsm()
        {
            this.battery = new Battery();
            this.display = new Display();
            this.listOfCalls = new List<Call>();
        }

        public Gsm(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;

            this.battery = new Battery();
            this.display = new Display();
            this.listOfCalls = new List<Call>();
        }

        public Gsm(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.listOfCalls = new List<Call>();
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
                    throw new ArgumentNullException("Value of the {0} can not be null", this.Model);
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Value of the {0} can not be null", this.Manufacturer);
                }

                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            private set
            {
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }

            private set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }

            private set
            {
                this.display = value;
            }
        }

        public IList<Call> ListOfCalls
        {
            get
            {
                // returns the copy of the List
                return new List<Call>(this.listOfCalls);
            }

            private set
            {
                this.listOfCalls = value;
            }
        }

        public string CallHistory()
        {
            var callhistory = new StringBuilder();
            foreach (var call in this.ListOfCalls)
            {
                callhistory.AppendLine(call.ToString());
            }

            return callhistory.ToString();
        }

        public void AddCall(Call call)
        {
            this.listOfCalls.Add(call);
        }

        public void DeleteCall(Call call)
        {
            if (!this.ListOfCalls.Contains(call))
            {
                throw new ArgumentException("Call does not exist");
            }

            this.listOfCalls.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.listOfCalls.Clear();
        }

        public decimal TotalPriceOfCalls()
        {
            decimal result = 0;

            foreach (var call in this.listOfCalls)
            {
                result += (call.CallDuration / 60) * Call.PricePerMinute;
            }

            return result;
        }

        public override string ToString()
        {
            var info = new StringBuilder();

            info.AppendLine("--->GSM info<---");
            info.AppendLine(string.Format($"Model: {this.Model}"));
            info.AppendLine(string.Format($"Manufacturer: {this.Manufacturer}"));
            info.AppendLine(string.Format($"Price: {this.Price}"));
            info.AppendLine(this.Battery.ToString());
            info.AppendLine(this.Display.ToString());

            return info.ToString();
        }
    }
}
