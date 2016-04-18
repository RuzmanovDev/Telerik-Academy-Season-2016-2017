namespace OddNumber
{
    using System;

    public class OddNumber
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] numbers = new long[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = long.Parse(Console.ReadLine());
            }

            long a = Singular(numbers);
            Console.WriteLine(a);
        }

        private static long Singular(long[] a)
        {
            long value = 0;
            for (int i = 0; i < a.Length; i++)
            {
                value = value ^ a[i];
            }

            return value;
        }
    }
}
