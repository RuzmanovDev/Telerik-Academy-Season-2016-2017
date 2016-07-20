namespace Shapes.Models
{
    using System;

    public abstract class Shape
    {
        protected double width;
        protected double height;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The width must be positive number");
                }

                this.width = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The heigth must be positive number");
                }

                this.height = value;
            }
        }

        public abstract double CalCulateSerficeArea();
    }
}
