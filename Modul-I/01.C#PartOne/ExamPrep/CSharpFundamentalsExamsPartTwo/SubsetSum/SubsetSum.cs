namespace SubsetSum
{
    using System;

    public class SubsetSum
    {
        public static void Main()
        {
            long s = long.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            long[] number = new long[n];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                number[i] = long.Parse(Console.ReadLine());
            }

            for (int i = 1; i < Math.Pow(2, n); i++)
            {
                if (s == CalculateSum(i, number))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        private static long CalculateSum(int subSet, long[] number)
        {
            long sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int bit = (subSet & (1 << i)) >> i;
                sum += number[i] * bit;
            }

            return sum;
        }
    }
}