namespace BatGoikoTower
{
    using System;

    public class BatGoikoTower
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char dot = '.';
            char dash = '-';
            char backSlash = '/';
            char slash = '\\';

            int dotsCount = n - 1;
            int elements = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string(dot, dotsCount));
                Console.Write(backSlash);
                if (i == 1 || i == 3 || i == 6 || i == 10 || i == 15 || i == 21 || i == 28 || i == 36)
                {
                    Console.Write(new string(dash, elements));
                }
                else
                {
                    Console.Write(new string(dot, elements));
                }
                Console.Write(slash);
                Console.WriteLine(new string(dot, dotsCount));
                dotsCount--;
                elements += 2;
            }
        }
    }
}
