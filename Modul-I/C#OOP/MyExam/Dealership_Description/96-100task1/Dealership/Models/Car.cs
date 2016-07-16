namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common.Enums;

    using Contracts;
    using Common;

    public class Car : Vehicle, ICar
    {
        private readonly int seats;

        public Car(string make, string model, decimal price, int seats)
            : base(VehicleType.Car, make, model, price)
        {

            Validator.ValidateIntRange(seats, Constants.MinSeats, Constants.MaxSeats,
                string.Format(Constants.NumberMustBeBetweenMinAndMax, "Seats", Constants.MinSeats, Constants.MaxSeats));
            this.seats = seats;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("  Seats: {0}", this.Seats));
            // TODO cooment to str;
            if (this.Comments.Count == 0)
            {
                builder.AppendLine("    --NO COMMENTS--");
            }else
            {
                builder.AppendLine("    --COMMENTS--");
                builder.Append(string.Join("", this.Comments));
                builder.AppendLine("    --COMMENTS--");
            }
            return base.ToString() + builder.ToString();
        }
    }
}
