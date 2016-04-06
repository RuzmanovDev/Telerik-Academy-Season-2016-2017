using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberToConvert = double.Parse(Console.ReadLine());
            string convertFrom = Console.ReadLine();
            string convertTo = Console.ReadLine();
            double multipliar = 0;
            switch (convertFrom)
            {
                case "mm": multipliar = 1000; break;
                case "cm": multipliar = 100; break;
                case "mi": multipliar = 0.000621371192; break;
                case "in": multipliar = 39.3700787; break;
                case "km": multipliar = 0.001; break;
                case "ft": multipliar = 3.2808399; break;
                case "yd": multipliar = 1.0936133; break;

                default:
                    break;
            }
            double answerinMeters = numberToConvert * multipliar;
            switch (convertTo)
            {
                case "mm": answerinMeters *= 1000; break;
                case "cm": answerinMeters = 100; break;
                case "mi": answerinMeters *= 0.000621371192; break;
                case "in": answerinMeters *= 39.3700787; break;
                case "km": answerinMeters *= 0.001; break;
                case "ft": answerinMeters *= 3.2808399; break;
                case "yd": answerinMeters *= 1.0936133; break;
            }
            Console.WriteLine(answerinMeters);
        }
    }
}
