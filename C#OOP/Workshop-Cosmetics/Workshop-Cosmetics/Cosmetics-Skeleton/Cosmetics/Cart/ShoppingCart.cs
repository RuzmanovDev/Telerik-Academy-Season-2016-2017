namespace Cosmetics.Cart
{
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Contracts;
    using Common;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.ProductList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get
            {
                return new List<IProduct>(this.productList);
            }

            private set
            {
                Validator.CheckIfNull(value,
                    string.Format(GlobalErrorMessages.ObjectCannotBeNull, "The Product list"));

                productList = value;
            }
        }

        public void AddProduct(IProduct product)
        {
            // TODO: duplicate code?
           // Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "product"));

            this.ProductList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "product"));
            this.ProductList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "product"));

            if (this.ProductList.Contains(product))
            {
                return true;
            }

            return false;
        }

        public decimal TotalPrice()
        {
            // TODO: is this proper?
            decimal result = this.ProductList.Sum(p => p.Price);

            return result;
        }
    }
}
