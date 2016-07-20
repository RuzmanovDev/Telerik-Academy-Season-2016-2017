using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo, IProduct
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
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Shampoo milliliters"));

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
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "UsageType"));

                this.usage = value;
            }
        }
        public override string Print()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.Print());
            builder.AppendLine(string.Format("   * Quantity: {0} ml", this.Milliliters));
            builder.AppendLine(string.Format("   * Usage: {0} ml", this.Usage));

            return builder.ToString();
        }

    }
}
