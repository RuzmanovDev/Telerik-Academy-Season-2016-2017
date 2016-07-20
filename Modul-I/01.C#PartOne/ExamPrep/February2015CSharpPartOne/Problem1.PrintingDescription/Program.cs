using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem1.PrintingDescription
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture =
     CultureInfo.InvariantCulture;

            int n = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());


            int totalSheet = n * s;
            double reams = totalSheet / 500.00d;
            double price = (double)reams * p;
            Console.WriteLine("{0:f2}", price);
        }
    }
}
