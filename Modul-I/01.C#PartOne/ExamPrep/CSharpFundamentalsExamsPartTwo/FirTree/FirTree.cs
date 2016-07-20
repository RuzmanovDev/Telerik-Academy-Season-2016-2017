namespace FirTree
{
    using System;

    public class FirTree
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = (n * 2) - 3;

            char asterix = '*';
            char dot = '.';
            int asterixCount = 1;
            int dotsCount = width / 2;

            for (int i = 0; i < n - 1; i++)
            {
                Console.Write(new string(dot, dotsCount));
                Console.Write(new string(asterix, asterixCount));
                Console.WriteLine(new string(dot, dotsCount));
                asterixCount += 2;
                dotsCount--;
            }

            Console.Write(new string(dot, width / 2));
            Console.Write(asterix);
            Console.WriteLine(new string(dot, width / 2));
        }
    }
}
