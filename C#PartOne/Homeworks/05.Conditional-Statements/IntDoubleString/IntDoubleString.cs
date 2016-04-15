namespace IntDoubleString
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class IntDoubleString
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string type = Console.ReadLine();

            switch (type)
            {
                case "integer":
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine(number + 1);
                    break;
                case "real":
                    double real = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:F2}", real + 1);
                    break;
                case "text":
                    string text = Console.ReadLine();
                    Console.WriteLine(text + "*");
                    break;
            }
        }
    }
}
