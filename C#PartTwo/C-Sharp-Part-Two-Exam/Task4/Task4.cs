namespace Task4
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class Task4
    {
        static void Main(string[] args)
        {
            // TODO: not finished
            int lines = int.Parse(Console.ReadLine());

            List<string> input = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                string currentLine = Console.ReadLine().Trim();
                currentLine = Regex.Replace(currentLine, @"\s+", "");
                if (currentLine != Environment.NewLine)
                {
                    input.Add(currentLine);
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            bool isInFunction = false;
            int nestTabs = 0;
            int tabSize = 4;

            var currentWord = new StringBuilder();
            for (int i = 0; i < input.Count; i++)
            {
                currentWord.Append(input[i]);
                if (currentWord.ToString() == "function" || currentWord.ToString() == "var" || currentWord.ToString() == "=")
                {
                    currentWord.Append(" ");
                    currentWord.Clear();
                }
                if (currentWord.ToString() == "{")
                {
                    isInFunction = true;
                    nestTabs++;
                    currentWord.Clear();
                }

                if (isInFunction)
                {
                    currentWord.Append(new string(' ', tabSize * nestTabs));
                }

            }

            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine(input[i]);
            }
        }
    }
}
