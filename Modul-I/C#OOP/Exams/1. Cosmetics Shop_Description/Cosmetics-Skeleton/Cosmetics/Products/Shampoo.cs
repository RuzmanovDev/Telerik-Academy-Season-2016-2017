namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Common;
    using Contracts;


    public class Shampoo : Product, IShampoo
    {
        private uint milliliters;
        private UsageType usage;

       

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
           : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            this.Price *= this.Milliliters;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }

            private set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Shampo name"));

                this.milliliters = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }

            private set
            {
                // Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull));

                this.usage = value;
            }
        }

        // 
        public override string Print()
        {
            var result = new StringBuilder();
            result.AppendLine(base.Print());
            result.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            result.Append(string.Format("  * Usage: {0}", this.Usage));
            return result.ToString();
        }

     
    }
}
