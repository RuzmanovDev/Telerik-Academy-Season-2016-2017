namespace JoroTheRabbit
{
    using System;
    using System.Linq;

    class JoroTheRabbit
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int maxLengh = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                for (int i = 1; i < numbers.Length; i++)
                {
                    // bool[] visited = new bool[numbers.Length]; this is useless 75/100 slow
                    int currentPosition = j;
                    int step = i;
                    int length = 0;
                    while (true)
                    {
                        // visited[currentPosition] = true;
                        length++;
                        int nextPosition = 0;
                        if (currentPosition + step >= numbers.Length)
                        {
                            nextPosition = (currentPosition + step) - numbers.Length;
                        }
                        else
                        {
                            nextPosition = currentPosition + step;
                        }
                        //int nextPosition = (currentPosition + step) % numbers.Length; // with this 95 /100

                        if (numbers[currentPosition] < numbers[nextPosition]) //&& !visited[nextPosition])
                        {
                            currentPosition = nextPosition;
                        }
                        else
                        {
                            maxLengh = Math.Max(length, maxLengh);
                            break;
                        }
                    }

                }
            }
            Console.WriteLine(maxLengh);

        }
    }
}
