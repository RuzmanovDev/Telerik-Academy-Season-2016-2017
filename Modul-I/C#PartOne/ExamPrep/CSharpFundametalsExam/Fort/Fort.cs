using System;

namespace Fort
{
    class Fort
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int upperArrowCount = n / 2;
            int spaceCounter = n * 2 - 2;
            int spaces = 0;
            int topDash = (n * 2) - (upperArrowCount * 2 + 4);
            //top
            Console.Write("/");
            Console.Write(new string('^', upperArrowCount));
            Console.Write("\\");
            if (n > 4)
            {
                Console.Write(new string('_', topDash));
            }
            Console.Write("/");
            Console.Write(new string('^', upperArrowCount));
            Console.WriteLine("\\");

            //middle
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("|");
                if (n > 4)
                {
                    spaces = upperArrowCount;
                }
                if (n > 4 && i == n - 3)
                {
                    spaces = upperArrowCount;
                    Console.Write(new string(' ', upperArrowCount + 1));
                    Console.Write(new string('_', topDash));
                    Console.Write(new string(' ', upperArrowCount + 1));
                    Console.WriteLine("|");
                }
                else
                {
                    Console.Write(new string(' ', n * 2 - 2));
                    Console.WriteLine("|");

                }


            }
            Console.Write("\\");

            Console.Write(new string('_', upperArrowCount));
            Console.Write("/");
            if (n > 4)
            {
                Console.Write(new string(' ', topDash));
            }
            Console.Write("\\");
            Console.Write(new string('_', upperArrowCount));
            Console.WriteLine("/");
        }
    }
}
