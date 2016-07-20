/*
 *  Problem 1. Structure
    Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
    Implement the ToString() to enable printing a 3D point.

    Problem 2. Static read-only field
    Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
    Add a static property to return the point O.
 * */

namespace Exercises_1_4
{
    using VersionAttribute;

    [Version(1, 0)]
    public struct Point
    {
        private static readonly Point pointO;

        static Point()
        {
            pointO = new Point(0, 0, 0);
        }

        public Point(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point PointO
        {
            get
            {
                return pointO;
            }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override string ToString()
        {
            return $"[{this.X}, {this.Y}, {this.Z}]";
        }
    }
}
