using System;

namespace CohesionAndCoupling
{
    public class Parallelepiped
    {
        private double width;
        private double height;
        private double depth;

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width must be > 0!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height mus be > 0!");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The depth must ne > 0!");
                }

                this.depth = value;
            }
        }

        public double CalcVolume()
        {
            double volume = this.width * this.height * this.depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = DistanceUtils.CalculateDistance3D(0, 0, 0, this.width, this.height, this.depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = DistanceUtils.CalculateDistance2D(0, 0, this.width, this.height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = DistanceUtils.CalculateDistance2D(0, 0, this.width, this.depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = DistanceUtils.CalculateDistance2D(0, 0, this.height, this.depth);
            return distance;
        }
    }
}
