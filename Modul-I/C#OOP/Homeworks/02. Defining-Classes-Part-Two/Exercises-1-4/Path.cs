/*
 *  Problem 4. Path
    Create a class Path to hold a sequence of points in the 3D space.
   
 * */

namespace Exercises_1_4
{
    using System.Collections.Generic;

    public class Path
    {
        private ICollection<Point> points;

        public Path(params Point[] points)
        {
            this.Points = new List<Point>(points);
        }

        public ICollection<Point> Points
        {
            get
            {
                return new List<Point>(this.points);
            }

            private set
            {
                this.points = value;
            }
        }
    }
}
