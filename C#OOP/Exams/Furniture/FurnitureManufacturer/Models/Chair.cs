namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class Chair : Furniture, IChair, IFurniture
    {
        public Chair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            // TODO: Validation for number of legs??
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; protected set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Legs: {0}", this.NumberOfLegs);
        }
    }
}
