namespace Shapes.Models
{
   public class Triangle : Shape
    {
        public Triangle(double width, double height) : base(width, height)
        {
        }

        public override double CalCulateSerficeArea()
        {
            return (this.Height * this.Width) / 2;
        }
    }
}
