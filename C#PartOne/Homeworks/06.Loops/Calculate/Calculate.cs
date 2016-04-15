namespace Calculate
{
    using System;

    public class Calculate
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());

            double sum = 1;
            int factoriel = 1;
            for (int i = 1; i <= n; i++)
            {
                factoriel *= i;
                sum += factoriel / Math.Pow(x, i);
            }

            Console.WriteLine("{0:F5}", sum);
        }
    }
}
