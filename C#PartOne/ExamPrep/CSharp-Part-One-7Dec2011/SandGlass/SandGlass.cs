namespace SandGlass
{
    using System;

    class SandGlass
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int topDots = 1;
            int stars = n;



            Console.WriteLine(new string('*', stars));
            stars -= 2;
            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.Write(new string('.', topDots));
                Console.Write(new string('*', stars));
                Console.WriteLine(new string('.', topDots));
                topDots++;
                stars -= 2;

            }
            Console.Write(new string('.', topDots));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', topDots));
            topDots--;
            stars += 2;
            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.Write(new string('.', topDots));
                Console.Write(new string('*', stars));
                Console.WriteLine(new string('.', topDots));
                topDots--;
                stars += 2;

            }
            Console.WriteLine(new string('*', stars));
        }
    }
}
