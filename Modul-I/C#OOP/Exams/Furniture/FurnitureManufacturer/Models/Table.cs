namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width)
        : base(model, material, price, height)
        {
            this.length = length;
            this.width = width;
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);
        }
    }
}
