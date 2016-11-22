using System;

namespace MyQueue
{
    class Startup
    {
        static void Main(string[] args)
        {
            var queue = new MyQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enque(i);
            }

            while (queue.Count!=0)
            {
                Console.WriteLine(queue.Dequeu());
            }
        }
    }
}
