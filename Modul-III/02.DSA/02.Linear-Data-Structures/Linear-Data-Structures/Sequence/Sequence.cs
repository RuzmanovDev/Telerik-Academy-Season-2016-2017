using System;
using System.Collections.Generic;

namespace Sequence
{
    public class Sequence
    {
        static void Main(string[] args)
        {
            // 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, .
            Queue<int> queue = new Queue<int>();

            int n = int.Parse(Console.ReadLine());

            queue.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                var number = queue.Dequeue();
                Console.Write(number + ", ");
                queue.Enqueue(number + 1);
                queue.Enqueue(2 * number + 1);
                queue.Enqueue(2 + number);
            }
        }
    }
}
