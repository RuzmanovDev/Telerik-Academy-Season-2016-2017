namespace SeriesOfLetters
{
    using System;
    using System.Text;

    class SeriesOfLetters
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder replacedText = new StringBuilder();
            // add one more symbol to the end so we can scan and append currentChar to the text
            text += " ";

            for (int i = 0; i < text.Length - 1; i++)
            {
                char currentChar = text[i];
                char nextChar = text[i + 1];
                if (currentChar != nextChar)
                {
                    replacedText.Append(currentChar);
                }
            }

            Console.WriteLine(replacedText.ToString());

        }
    }
}