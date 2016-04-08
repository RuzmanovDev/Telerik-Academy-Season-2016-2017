namespace DancingBits
{
    using System;

    class DancingBits
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string numbers = "";//Convert.ToString(number, 2);
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers += Convert.ToString(number, 2);
            }
            //Console.WriteLine(numbers);
            int dancingBits = 0;
            int counter = 1;
            char prevBit = numbers[0];
            for (int i = 1; i < numbers.Length ; i++)
            {
                char currentBit = numbers[i];
                if (currentBit == prevBit)
                {
                    counter++;
                }
                else
                {
                    if (counter == k)
                    {
                        dancingBits++;
                        counter = 1;
                    }

                    counter = 1;
                    prevBit = currentBit;
                }

                prevBit = currentBit;

            }

            if (counter == k)
            {
                dancingBits++;
                counter = 1;
            }

            Console.WriteLine(dancingBits);
        }
    }
}
