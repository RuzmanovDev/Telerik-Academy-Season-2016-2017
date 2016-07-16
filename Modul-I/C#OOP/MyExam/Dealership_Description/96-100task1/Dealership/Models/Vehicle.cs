namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using Common.Enums;
    using Common;

    public abstract class Vehicle : IVehicle
    {
        private string make;
        private string model;
        private decimal price;
        private VehicleType vehicleType;
        private readonly int wheels;
        private IList<IComment> comments;


        public Vehicle(VehicleType vehicleType, string make, string model, decimal price)
        {
            this.Type = vehicleType;
            this.Make = make;
            this.Model = model;
            this.Price = price;
            // TODO is this right?
            this.wheels = (int)this.Type;
            Validator.ValidateIntRange(wheels, Constants.MinWheels, Constants.MaxWheels,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Wheels", Constants.MinWheels, Constants.MaxWheels));

            this.comments = new List<IComment>();
        }

        public IList<IComment> Comments
        {
            get
            {
                // TODO: maybe return copy
                return this.comments;
            }

            private set
            {
                Validator.ValidateNull(value, Constants.CommentCannotBeNull);
                this.comments = value;
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }

            private set
            {
                // TO DO validate for null
                Validator.ValidateIntRange(value.Length, Constants.MinMakeLength, Constants.MaxMakeLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Make", Constants.MinMakeLength, Constants.MaxMakeLength));

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validator.ValidateNull(value, "Model cannot be null");
                Validator.ValidateIntRange(value.Length, Constants.MinModelLength, Constants.MaxModelLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Model", Constants.MinModelLength, Constants.MaxModelLength));

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                Validator.ValidateDecimalRange(value, Constants.MinPrice, Constants.MaxPrice,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Price", Constants.MinPrice, Constants.MaxPrice));

                this.price = value;
            }
        }

        public VehicleType Type
        {
            get
            {
                return this.vehicleType;
            }

            private set
            {
                Validator.ValidateNull(value, "Vahicle type cannot be null");
                this.vehicleType = value;
            }
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("{0}:", this.Type));
            builder.AppendLine(string.Format("  Make: {0}", this.Make));
            builder.AppendLine(string.Format("  Model: {0}", this.Model));
            builder.AppendLine(string.Format("  Wheels: {0}", this.Wheels));
            builder.AppendLine(string.Format("  Price: ${0}", this.Price));


            return builder.ToString();
        }
    }
}
