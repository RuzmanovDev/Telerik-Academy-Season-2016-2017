namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    public class Start
    {
        public static void Main(string[] args)
        {
            // create some figures 
            var square = new Square(4, 4);
            var rectangle = new Rectangle(2, 4);
            var triangle = new Triangle(5, 2);
            
            // put them in a list
            var arrOfShapes = new List<Shape>()
            {
                square, rectangle, triangle
            };
            
            // calculate the are of each one and return it to annonymous type with name and area
            var surfface = arrOfShapes
                .Select(shape => new
                {
                    Figure = shape.GetType().Name,
                    Area = shape.CalCulateSerficeArea()
                });

            // print the results
            foreach (var shape in surfface)
            {
                Console.WriteLine($"The area of the  {shape.Figure} is  {shape.Area}");
            }
        }
    }
}
