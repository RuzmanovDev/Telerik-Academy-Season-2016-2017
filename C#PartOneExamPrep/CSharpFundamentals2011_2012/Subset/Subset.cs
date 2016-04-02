using System;

class Subset
{
    static void Main(string[] args)
    {

        long sum = long.Parse(Console.ReadLine());
        long length = long.Parse(Console.ReadLine());

        long[] numbers = new long[length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }

        long subsets = 0;
        long tempSum = 0;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            tempSum = numbers[i];
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[i] == numbers[j] && sum == numbers[i])
                {
                    subsets++;
                }

                tempSum += numbers[j];
                if (tempSum == sum)
                {
                    subsets++;
                }
            }
        }


        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < nu; j++)
            {

            }
        }
        Console.WriteLine(subsets);
    }
}
