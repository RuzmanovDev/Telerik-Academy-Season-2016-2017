namespace SayHello
{
    using System;

    public class SayHello
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Greetings(name);
        }

        private static void Greetings(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
