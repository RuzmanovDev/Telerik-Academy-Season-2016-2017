namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height) : base(width, height)
        {
        }

        public override double CalCulateSerficeArea()
        {
            return this.height * this.width;
        }
    }
}
