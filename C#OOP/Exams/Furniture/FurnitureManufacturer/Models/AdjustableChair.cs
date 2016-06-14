namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class AdjustableChair : Chair, IAdjustableChair, IFurniture
    {
        public AdjustableChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) : base(model, material, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
    }
}
