namespace ParseTags
{
    using System;
    using System.Text;

    class ParseTags
    {
        private const string OPENING_UP_CASE = "<upcase>";
        private const string CLOSING_UP_CASE = "</upcase>";

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string inputToUpper = ConvertToUpper(input);
            Console.WriteLine(inputToUpper);
        }

        private static string ConvertToUpper(string input)
        {
            StringBuilder text = new StringBuilder();
            bool foundOppeningTag = false;
            bool foundClosingTag = false;


            for (int i = 0; i < input.Length; i++)
            {

                char currentChar = input[i];

                if (foundOppeningTag)
                {
                    if (input[i] != '<')
                    {
                        text.Append(input[i].ToString().ToUpper());
                        continue;
                    }
                    if (input[i] == '<')
                    {
                        foundClosingTag = true;
                        foundOppeningTag = false;
                        i += CLOSING_UP_CASE.Length - 1; // -1 because i will incriment in the next iteration of the cycle 
                    }
                }

                if (foundClosingTag)
                {
                    foundClosingTag = false;
                    continue;
                }

                if (currentChar != '<')
                {
                    text.Append(currentChar);
                }
                else
                {
                    foundOppeningTag = true;
                    i += OPENING_UP_CASE.Length - 1;
                }

            }
            return text.ToString();
        }
    }
}
