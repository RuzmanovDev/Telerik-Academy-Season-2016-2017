namespace OddAndEvenProduct
{
    using System;
    using System.Linq;

    public class OddAndEvenProduct
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long evenProduct = 1;
            long oddProduct = 1;

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    oddProduct *= numbers[i];
                }
                else
                {
                    evenProduct *= numbers[i];
                }
            }

            if (evenProduct == oddProduct)
            {
                Console.WriteLine("yes {0}", evenProduct);
            }
            else
            {
                Console.WriteLine("no {0} {1}", oddProduct, evenProduct);
            }
        }
    }
}
