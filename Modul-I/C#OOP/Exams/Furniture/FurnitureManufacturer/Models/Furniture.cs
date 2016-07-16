namespace FurnitureManufacturer.Models
{
    using System;
    using System.Linq;

    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        private decimal height;
        private string model;
        private decimal price;

        public Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Height = height;
            this.MaterialType = material;
            this.Model = model;
            this.Price = price;
        }

        public virtual decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentException("He height canno be less or equal to 0");
                }

                this.height = value;
            }
        }

        public string Material
        {
            get
            {
                return this.MaterialType.ToString();
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("The model must be at least 3 symbols");
                }

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The price cannot be less or equal to 0.00");
                }

                this.price = value;
            }
        }

        protected MaterialType MaterialType { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name,
                this.Model,
                this.MaterialType,
                this.Price,
                this.Height);
        }
    }
}