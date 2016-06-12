/*
    Problem 3. Static class
    Write a static class with a static method to calculate the distance between two points in the 3D space.
 * */
namespace Exercises_1_4
{
    using System;

    public static class PointDistance
    {
        public static double CalculateDistance(Point p1, Point p2)
        {
            double distance = 0;
            distance = 
                Math.Sqrt(Math.Pow(p2.X - p1.X, 2) 
                + Math.Pow(p2.Y - p1.Y, 2) 
                + Math.Pow(p2.Z - p1.Z, 2));

            return distance;
        }
    }
}
