namespace SevenlandNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SevenlandNumbers
    {
        static void Main(string[] args)
        {
            //95/100
            long input = long.Parse(Console.ReadLine());
            string answer = "";
            int iteration = 1;

            if (input < 6)
            {
                Console.WriteLine(input + 1);
                return;
            }
            while (input > 0)
            {
                long currentNumber = input % 10;
                input /= 10;

                if (currentNumber < 6 && iteration == 1)
                {
                    currentNumber++;
                    answer += currentNumber;

                }
                if (currentNumber < 6 && iteration != 1)
                {
                    answer += currentNumber;
                }

                if (currentNumber >= 6 && iteration == 1)
                {
                    currentNumber = 0;
                    answer += currentNumber;
                    // currentNumber = input % 10;
                    input++;
                }
                if (currentNumber > 6 && iteration != 1)
                {
                    currentNumber = 0;
                    answer += currentNumber;
                    // currentNumber = input % 10;
                    input++;
                }
                if (currentNumber == 6 && iteration != 1)
                {
                    currentNumber = 6;
                    answer += currentNumber;
                    // currentNumber = input % 10;

                }

                iteration++;

            }
            for (int i = answer.Length - 1; i >= 0; i--)
            {
                Console.Write(answer[i]);
            }
            Console.WriteLine();
        }
    }
}
