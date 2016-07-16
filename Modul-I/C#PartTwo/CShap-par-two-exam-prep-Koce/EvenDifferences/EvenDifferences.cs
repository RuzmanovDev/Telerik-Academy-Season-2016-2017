namespace EvenDifferences
{
    using System;
    using System.Linq;

    class EvenDifferences
    {

        // 1. read input
        // 2. put the input numbers in an array
        // 3. iterate over the array and calculate the usm 
        // 3.1 find absolute difference of current and previous
        // 3.4 if even difference, sum it 
        // 3.3 make a jum even or odd 
        // 4. print the sum

        static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            long sum = 0;

            int i = 1;
            while (i < sequence.Length)
            {
                long absDif = Math.Abs(sequence[i] - sequence[i - 1]);

                if (absDif%2==0)
                {
                    sum += absDif;
                    i += 2;
                }
                else
                {
                    i++;
                }
            }
            Console.WriteLine(sum);
        }
    }
}