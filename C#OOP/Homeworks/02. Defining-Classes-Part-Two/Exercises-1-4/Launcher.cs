namespace Exercises_1_4
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Making some points
            var point = new Point(2, 3, 4);
            var anotherPoint = new Point(44, 2, 1.22);
            var yetAnotherPoint = new Point(2, 11, 421);

            // Calculating the distance between two points
            var distance = PointDistance.CalculateDistance(point, anotherPoint);
            Console.WriteLine(distance);

            // Create isntance of the call Path
            Path points = new Path(point, anotherPoint, yetAnotherPoint);

            // Get the coletion of points from the property
            var pointColection = points.Points;

            foreach (var item in pointColection)
            {
                Console.WriteLine(item);
            }

            // writes Points to file  
            PathStorage.SavePointsToFile(point, anotherPoint, yetAnotherPoint);

            // reads Points from a file
            var readFromFilePoints = PathStorage.ReadPointsFromFile(@"..\..\ReadPoints.txt");
            
            // prints the readFromFilePoints
            foreach (var readPoint in readFromFilePoints)
            {
                Console.WriteLine(readPoint);
            }

            // get the version of the point Problem 11. Version attribute
            Type type = typeof(Point);
            object[] attr = type.GetCustomAttributes(false);
            foreach (var item in attr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
