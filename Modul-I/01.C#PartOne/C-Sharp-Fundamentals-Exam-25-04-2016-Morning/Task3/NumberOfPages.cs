namespace Task3
{
    using System;

    class NumberOfPages
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = 0;

            int totalDigits = 0;
            for (int i = n; i >= 0; i--)
            {
                result = 0;
                int temp = i;
                while (temp != 0)
                {
                    temp /= 10;
                    result++;
                }

                totalDigits += result;
            }

            Console.WriteLine(totalDigits);
        }
    }
}
