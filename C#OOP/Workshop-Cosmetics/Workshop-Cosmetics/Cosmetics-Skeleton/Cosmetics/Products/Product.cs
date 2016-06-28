namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Common;
    using Contracts;

    public abstract class Product : IProduct
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;

        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string brand;
        private GenderType gender;
        private string name;
        private decimal price;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            protected set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product Brand"));
                Validator.CheckIfStringLengthIsValid(value, BrandMaxLength, BrandMinLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", BrandMinLength, BrandMaxLength));

                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }

            protected set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product gender"));

                this.gender = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, this.Name));

                Validator.CheckIfStringLengthIsValid(value, NameMaxLength, NameMinLength, string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", NameMinLength, NameMaxLength));
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            protected set
            {
                // TODO: price null?
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product price"));
                if (value < 0)
                {
                    throw new ArgumentException("The price of the product cannot be null!");
                }
                this.price = value;
            }
        }

        public virtual string Print()
        {
            var builder = new StringBuilder();
            //          - { product brand} – { product name}:
            //*Price: ${ product price}
            //          *For gender: Men / Women / Unisex

            builder.AppendLine(string.Format("- {0} - {1}", this.Brand, this.Name));
            builder.AppendLine(string.Format("   * Price: ${0}", this.Price));
            builder.AppendLine(string.Format("   * For gender: {0}", this.Gender));

            return builder.ToString();
        }
    }
}
