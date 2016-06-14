namespace MobilePhoneDevice
{
    using System.Text;

    public class Display
    {
        public Display()
        {
        }

        public Display(int size, int numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public int? Size { get; private set; }

        public int? NumberOfColors { get; private set; }

        public override string ToString()
        {
            var info = new StringBuilder();

            info.AppendLine("--->Display info<---");
            info.AppendLine(string.Format($"Size: {this.Size}"));
            info.Append(string.Format($"Number of colors: {this.NumberOfColors}"));

            return info.ToString();
        }
    }
}
