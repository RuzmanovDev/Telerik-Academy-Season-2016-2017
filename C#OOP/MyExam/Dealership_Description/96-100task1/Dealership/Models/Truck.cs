namespace Dealership.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common.Enums;
    using Common;

    public class Truck : Vehicle, ITruck
    {
        private readonly int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(VehicleType.Truck, make, model, price)
        {
            Validator.ValidateIntRange(weightCapacity, Constants.MinCapacity, Constants.MaxCapacity,
                string.Format(Constants.NumberMustBeBetweenMinAndMax, "Weight capacity", Constants.MinCapacity, Constants.MaxCapacity));

            this.weightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("  Weight Capacity: {0}t", this.WeightCapacity));
            if (this.Comments.Count == 0)
            {
                builder.AppendLine("    --NO COMMENTS--");
            }
            else
            {
                builder.AppendLine("    --COMMENTS--");
                builder.Append(string.Join("", this.Comments));
                builder.AppendLine("    --COMMENTS--");

            }

            return base.ToString() + builder.ToString();

        }
    }
}
