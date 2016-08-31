using System;

namespace Task1
{
    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static Size GetRotatedSize(
            Size size, double angle)
        {
            var sizeWidth = CalculateAbsoluteWidth(size, angle);
            var sizeHeigth = CalculateAbsoluteHeight(size, angle);
            var result = new Size(sizeWidth, sizeHeigth);

            return result;
        }

        private static double CalculateAbsoluteWidth(Size size, double angle)
        {
            double abosuluteWidth = (Math.Abs(Math.Cos(angle)) * size.width) + (Math.Abs(Math.Sin(angle)) * size.height);

            return abosuluteWidth;
        }

        private static double CalculateAbsoluteHeight(Size size, double angle)
        {
            double absoluteHeigth = (Math.Abs(Math.Sin(angle)) * size.width) + (Math.Abs(Math.Cos(angle)) * size.height);

            return absoluteHeigth;
        }
    }
}
