using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Recursion(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(n);
            Recursion(n - 1);
            Console.WriteLine(n);
        }
        static void Main(string[] args)
        {
            Recursion(4);
        }
    }
}
