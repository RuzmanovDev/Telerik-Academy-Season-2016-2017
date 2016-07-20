using System;

namespace FallenInLove
{
    class FallenInLove
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int topDots = n * 2;

            //topPart
            Console.Write("##");
            Console.Write(new string('.', topDots));
            Console.Write("##");
            Console.Write(new string('.', topDots));
            Console.WriteLine("##");

            topDots -= 2;
            int tildaCounter = 1;
            int dotsInsideRombCount = 2;
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write("#");
                Console.Write(new string('~', tildaCounter));
                Console.Write("#");
                Console.Write(new string('.', topDots));
                Console.Write("#");
                Console.Write(new string('.', dotsInsideRombCount));
                Console.Write("#");
                Console.Write(new string('.', topDots));
                Console.Write("#");
                Console.Write(new string('~', tildaCounter));
                Console.WriteLine("#");
                tildaCounter++;
                topDots -= 2;
                dotsInsideRombCount += 2;
            }
            //secondPart
            int bottomDots = 1;

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('.', bottomDots));
                Console.Write("#");
                Console.Write(new string('~', tildaCounter));
                Console.Write("#");
                Console.Write(new string('.', dotsInsideRombCount));
                Console.Write("#");
                Console.Write(new string('~', tildaCounter));
                Console.Write("#");
                Console.WriteLine(new string('.', bottomDots));
                bottomDots += 2;
                tildaCounter--;
                dotsInsideRombCount -= 2;
            }
            Console.Write(new string('.', bottomDots));
            Console.Write(new string('#', 4));
            Console.WriteLine(new string('.', bottomDots));
            bottomDots++;
           // bottomDots -= 2;
            //bottom
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('.', bottomDots));
                Console.Write(new string('#', 2));
                Console.WriteLine(new string('.', bottomDots));
            }
        }
    }
}
