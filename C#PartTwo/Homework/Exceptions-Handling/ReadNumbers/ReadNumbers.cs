namespace ReadNumbers
{
    using System;

    class ReadNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            try
            {
                for (int i = 1; i < numbers.Length; i++)
                {
                    if (numbers[i] <= numbers[i - 1] || numbers[i] <= 1 || numbers[i] >= 100)
                    {
                        throw new Exception();
                    }
                }

                Console.Write("1 < ");
                Console.Write(string.Join(" < ", numbers));
                Console.WriteLine(" < 100");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");

            }
        }
    }
}