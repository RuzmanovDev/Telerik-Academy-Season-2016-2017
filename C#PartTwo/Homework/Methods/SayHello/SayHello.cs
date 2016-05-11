namespace SayHello
{
    using System;

    class SayHello
    {
        static void Main(string[] args)
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
