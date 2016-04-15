namespace MMSA
{
    using System; 
    using System.Globalization;
    using System.Linq;
    using System.Threading;
  
    public class MMSA
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int n = int.Parse(Console.ReadLine());
            double[] numbers = new double[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = double.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);
            double min = numbers[0];
            double max = numbers[n - 1];
            double sum = numbers.Sum();
            double average = numbers.Average();

            Console.WriteLine("min={0:F2}", min);
            Console.WriteLine("max={0:F2}", max);
            Console.WriteLine("sum={0:F2}", sum);
            Console.WriteLine("avg={0:F2}", average);
        }
    }
}
