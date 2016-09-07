namespace TexToNumber
{
    using System;

    public class TexToNumber
    {
        public static void Main(string[] args)
        {
            // read Input
            int module = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            long result = 0;

            text = text.ToLower();
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (ch == '@')
                {
                    break;
                }
                else if (char.IsDigit(ch))
                {
                    result *= (ch - '0');
                }
                else if (char.IsLetter(ch))
                {
                    // ch = char.ToLower(ch);
                    result += ch - 'a';
                }
                else
                {
                    result %= module;
                }
            }
            // print result 
            Console.WriteLine(result);

        }
    }
}
