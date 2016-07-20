namespace CoffeMachine
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class CoffeMachine
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            int n4 = int.Parse(Console.ReadLine());
            int n5 = int.Parse(Console.ReadLine());

            decimal devAmmount = decimal.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());
            decimal moneyInMachine = (n1 * 0.05M) + (n2 * 0.10M) + (n3 * 0.20M) + (n4 * 0.50M) + (n5 * 1.00M);
            decimal moneyLeft = moneyInMachine - (devAmmount - price);

            if (devAmmount >= price)
            {
                if (moneyLeft >= 0)
                {
                    Console.WriteLine("Yes {0:F2}", moneyLeft);
                }
                else
                {
                    Console.WriteLine("No {0:F2}", (devAmmount - price) - moneyInMachine);
                }
            }
            else
            {
                Console.WriteLine("More {0:F2}", price - devAmmount);
            }
        }
    }
}
