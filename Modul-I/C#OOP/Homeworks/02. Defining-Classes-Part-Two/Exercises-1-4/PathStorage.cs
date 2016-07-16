/*
 *  Create a static class PathStorage with static methods to save and load paths from a text file.
    Use a file format of your choice.
 * */
namespace Exercises_1_4
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public static class PathStorage
    {
        public static void SavePointsToFile(params Point[] points)
        {
            var writter = new StreamWriter(@"..\..\Points.txt");
            using (writter)
            {
                foreach (var point in points)
                {
                    writter.WriteLine(point);
                }
            }
        }

        public static ICollection<Point> ReadPointsFromFile(string path)
        {
            ICollection<Point> points = new List<Point>();
            var builder = new StringBuilder();

            var reader = new StreamReader(path);
            using (reader)
            {
                builder.AppendLine(reader.ReadToEnd());
            }

            var splittedPointCoords = builder.ToString()
                .Split(new char[] { ',', ' ', '[', ']', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splittedPointCoords.Length - 2; i += 3)
            {
                var x = double.Parse(splittedPointCoords[i]);
                var y = double.Parse(splittedPointCoords[i + 1]);
                var z = double.Parse(splittedPointCoords[i + 2]);

                var point = new Point(x, y, z);
                points.Add(point);
            }

            return points;
        }
    }
}
