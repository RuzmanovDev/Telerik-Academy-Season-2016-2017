namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dealership.Common.Enums;
    using Dealership.Common;

    using Dealership.Contracts;
  
    public class Motorcycle : Vehicle, IMotorcycle
    {
        private string category;

        public Motorcycle(string make, string model, decimal price,string category)
            : base(VehicleType.Motorcycle, make, model, price)
        {
            Validator.ValidateNull(category, "Category cannot be null");
            Validator.ValidateIntRange(category.Length, Constants.MinCategoryLength, Constants.MaxCategoryLength,
                string.Format(Constants.StringMustBeBetweenMinAndMax, "Category", Constants.MinCategoryLength, Constants.MaxCategoryLength));

            this.category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("  Category: {0}", this.Category));
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
