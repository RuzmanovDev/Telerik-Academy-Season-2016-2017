namespace FrequentNumber
{
    using System;

    class FrequentNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);

            int currentRepeat = 1;
            int maxRepeat = 1;
            int element = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {

                if (numbers[i] == numbers[i + 1])
                {
                    currentRepeat++;
                }
                else
                {
                    currentRepeat = 1;
                }

                if (currentRepeat > maxRepeat)
                {
                    maxRepeat = currentRepeat;
                    element = numbers[i];
                }
            }

            Console.WriteLine("{0} ({1} times)",element,maxRepeat);
        }
    }
}
