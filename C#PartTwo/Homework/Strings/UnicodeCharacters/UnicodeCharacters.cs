namespace UnicodeCharacters
{
    using System;

    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            foreach (char c in input)
            {
                Console.Write("\\u{0:x4}", (int)c);
            }
            Console.WriteLine();
        }
    }
}