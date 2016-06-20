namespace Shapes.Models
{
    using System;

    public class Square : Shape
    {
        public Square(double width, double height) : base(width, height)
        {
        }

        // keep the width equal to the height
        public override double Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value != this.width)
                {
                    throw new ArgumentException("The width of the square must be equal to its height!");
                }

                this.height = value;
            }
        }

        public override double CalCulateSerficeArea()
        {
            return this.Width * this.Height;
        }
    }
}
