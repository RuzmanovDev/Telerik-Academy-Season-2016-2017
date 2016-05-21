namespace SubstringInText
{
    using System;

    class SubstringInText
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine().ToLower();

            string text = Console.ReadLine().ToLower();

            int counter = 0;
            for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            {
                string currentSubString = text.Substring(i, pattern.Length);
                if (currentSubString.Equals(pattern))
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
