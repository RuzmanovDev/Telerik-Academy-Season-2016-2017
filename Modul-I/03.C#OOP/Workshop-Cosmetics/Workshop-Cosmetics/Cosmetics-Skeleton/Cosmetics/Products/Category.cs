namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;
    using Common;

    public class Category : ICategory
    {
        private const int CategoryNameMinLength = 2;
        private const int CategoryNameMaxLength = 15;

        private string name;
        private ICollection<IProduct> productList;

        public Category(string name)
        {
            this.Name = name;
            this.ProductList = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value,
                    string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name"));

                Validator.CheckIfStringLengthIsValid(value,
                    CategoryNameMaxLength,
                    CategoryNameMinLength,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                        "Category name", CategoryNameMinLength, CategoryNameMaxLength));

                this.name = value;
            }
        }

        public ICollection<IProduct> ProductList
        {
            get
            {
                // return the copy of the collection
                return new List<IProduct>(this.productList);
            }

            private set
            {
                Validator.CheckIfNull(value,
                    string.Format(GlobalErrorMessages.ObjectCannotBeNull, "The list of products "));

                this.productList = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {

            //Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "cosmetics"));

            // always use the prooperty
            this.productList.Add(cosmetics);
        }

        public string Print()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("{0} category - {1} {2} in total", this.Name, this.ProductList.Count,
                this.ProductList.Count == 1 ? "product" : "products"));

           
            var sortedList = this.ProductList
                .OrderBy(brandName => brandName.Brand)
                .ThenByDescending(price => price.Price);

            foreach (var product in sortedList)
            {
                builder.AppendLine(product.Print());
            }

            return builder.ToString().Trim();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
          //  Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "cosmetics"));

            this.productList.Remove(cosmetics);
        }
    }
}
