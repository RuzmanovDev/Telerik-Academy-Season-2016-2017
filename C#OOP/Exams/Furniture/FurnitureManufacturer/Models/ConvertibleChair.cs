namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair, IFurniture
    {
        private const decimal HeightWhenChonverted = 0.10m;
        private bool isConverted = false;

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) : base(model, material, price, height, numberOfLegs)
        {
        }

        public override decimal Height
        {
            get
            {
                if (this.IsConverted)
                {
                    return HeightWhenChonverted;
                }

                return base.Height;
            }

            protected set
            {
                base.Height = value;
            }
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
        }

        public void Convert()
        {
            this.isConverted = !this.isConverted;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
