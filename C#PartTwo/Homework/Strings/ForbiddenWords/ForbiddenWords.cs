namespace ForbiddenWords
{
    using System;
    using System.Text.RegularExpressions;

    class ForbiddenWords
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] forbidenWords = Console.ReadLine().Split(' ');
            string patten = string.Empty;
            for (int i = 0; i < forbidenWords.Length; i++)
            {
                if (i == forbidenWords.Length - 1)
                {
                    patten += forbidenWords[i];
                }
                else
                {
                    patten += forbidenWords[i] + "|";
                }
            }


            string result = Regex.Replace(text, patten, word => new string('*', word.Length));

            Console.WriteLine(result);
        }
    }
}