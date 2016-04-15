namespace NumbersFromOneToN
{
    using System;

    public class NumbersFromOneToN
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine();
        }
    }
}
