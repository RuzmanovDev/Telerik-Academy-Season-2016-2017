using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestSequence
{
    public class ShortestSequence
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int seekedNumber = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(startNumber);

            while (true)
            {
                int number = queue.Dequeue();
                Console.Write(number + ", ");
                if (number == seekedNumber)
                {
                    break;
                }

                queue.Enqueue(number * 2);
                queue.Enqueue(number + 2);
                queue.Enqueue(number + 1);
            }
        }
    }
}
