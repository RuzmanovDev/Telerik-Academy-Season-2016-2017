using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Startup
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<int>();

            for (int i = 0; i < 15 ; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine($"Count before popping {stack.Count}");
            while (stack.Count !=0)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine($"Count after popping {stack.Count}");
        }
    }
}
