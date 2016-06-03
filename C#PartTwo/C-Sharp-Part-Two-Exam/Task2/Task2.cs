namespace Task2
{
    using System;
    using System.Linq;

    class Task2
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            int position = 0;
            long sum = 0;
            int rounds = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "stop")
                {
                    break;
                }
                string[] commands = command.Split(' ').ToArray();

                int numberOfSteps = int.Parse(commands[0]);
                string direction = commands[1];
                int step = int.Parse(commands[2]);

                for (int i = 0; i < numberOfSteps; i++)
                {
                    if (direction == "right")
                    {
                        position = (position + step) % numbers.Length;
                    }
                    else
                    {
                        position = (position - step) % numbers.Length;
                        if (position < 0)
                        {
                            position += numbers.Length; // ????
                        }
                    }

                    sum += numbers[position];

                }

                rounds++;
            }

            double result = (double)sum / rounds;
            Console.WriteLine("{0:F1}", result);
        }
    }
}
