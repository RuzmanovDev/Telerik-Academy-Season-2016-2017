namespace IndexOfLetters
{
    using System;

    class IndexOfLetters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] alphabet = new char[26];
            char symbol = 'a';
            for (int i = 0; i < alphabet.Length; i++)
            {
                alphabet[i] = symbol;
                symbol++;
            }

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];
                Console.WriteLine(Array.IndexOf(alphabet, currentSymbol));
            }
        }
    }
}
