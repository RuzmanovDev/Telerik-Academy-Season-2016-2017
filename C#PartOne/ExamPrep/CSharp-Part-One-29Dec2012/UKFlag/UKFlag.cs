namespace UKFlag
{
    using System;

    public class UKFlag
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int onePart = (n - 1) / 2;
            int outDots = 0;
            int innerDots = (n - 3) / 2;

            char dot = '.';
            char slash = '\\';
            char secondSLah = '/';
            char line = '|';
            char dash = '-';

            for (int i = 0; i < onePart; i++)
            {
                Console.Write(new string(dot, outDots));
                Console.Write(slash);
                Console.Write(new string(dot, innerDots));
                Console.Write(line);
                Console.Write(new string(dot, innerDots));
                Console.Write(secondSLah);
                Console.WriteLine(new string(dot, outDots));
                outDots++;
                innerDots--;
            }

            Console.Write(new string(dash, (n - 1) / 2));
            Console.Write('*');
            Console.WriteLine(new string(dash, (n - 1) / 2));
            outDots--;
            innerDots = 0;

            for (int i = 0; i < onePart; i++)
            {
                Console.Write(new string(dot, outDots));
                Console.Write(secondSLah);
                Console.Write(new string(dot, innerDots));
                Console.Write(line);
                Console.Write(new string(dot, innerDots));
                Console.Write(slash);
                Console.WriteLine(new string(dot, outDots));
                outDots--;
                innerDots++;
            }
        }
    }
}
