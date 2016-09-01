using System.Text;

namespace Abstraction
{
    public abstract class Figure : IFigure
    {
        public abstract double CalcSurface();

        public abstract double CalcPerimeter();

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"I am a {this.GetType().Name}.");
            builder.Append($"My perimeter is {this.CalcPerimeter():f2}. ");
            builder.AppendLine($"My surface is {this.CalcSurface():f2}");

            return builder.ToString();
        }
    }
}
