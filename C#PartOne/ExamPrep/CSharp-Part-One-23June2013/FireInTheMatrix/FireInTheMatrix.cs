namespace FireInTheMatrix
{
    using System;

    public class FireInTheMatrix
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char dot = '.';
            char hashtag = '#';
            char slash = '/';
            char backslash = '\\';

            int dots = (n - 2) / 2;
            int middleDots = 2;
            Console.Write(new string(dot, dots));
            Console.Write(new string(hashtag, 2));
            Console.WriteLine(new string(dot, dots));
            dots--;

            for (int i = 0; i < (n / 2) - 1; i++)
            {
                Console.Write(new string(dot, dots));
                Console.Write('#');
                Console.Write(new string(dot, middleDots));
                Console.Write('#');
                Console.WriteLine(new string(dot, dots));
                dots--;
                middleDots += 2;
            }
            dots++;
            middleDots -= 2;
            for (int i = 0; i < n / 4; i++)
            {
                Console.Write(new string(dot, dots));
                Console.Write('#');
                Console.Write(new string(dot, middleDots));
                Console.Write('#');
                Console.WriteLine(new string(dot, dots));
                dots++;
                middleDots -= 2;
            }

            Console.WriteLine(new string('-', n));
            dots = 0;
            int slashesh = n / 2;
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write(new string(dot, dots));
                Console.Write(new string(backslash, slashesh));
                Console.Write(new string(slash, slashesh));
                Console.WriteLine(new string(dot, dots));
                slashesh--;
                dots++;
            }
        }
    }
}
