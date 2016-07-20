namespace UnicodeCharacters
{
    using System;
    using System.Text;

    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var answer = new StringBuilder();

            foreach (char c in input)
            {
                answer.AppendFormat("\\u{0:X4}", (int)c);
            }

            Console.WriteLine(answer.ToString());
        }
    }
}