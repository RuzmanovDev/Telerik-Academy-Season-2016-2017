namespace MovingLetters
{
    using System;
    using System.Linq;
    using System.Text;

    class MovingLetters
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(' ').ToArray();
            StringBuilder text = new StringBuilder();

            int max = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string currentWord = input[i];
                if (currentWord.Length > max)
                {
                    max = currentWord.Length;
                }
            }

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    string word = input[j];
                    if (i < word.Length)
                    {
                        text.Append(word[word.Length - 1 - i]);
                    }
                }
            }

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                int position = char.ToLower(currentChar) - 'a' + 1;
                int nextPosiion = (i + position) % text.Length;
                text.Remove(i, 1);
                text.Insert(nextPosiion, currentChar);
            }

            Console.WriteLine(text);
        }
    }
}
