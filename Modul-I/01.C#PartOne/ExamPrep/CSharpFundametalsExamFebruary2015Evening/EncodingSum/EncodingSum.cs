namespace EncodingSum
{
    using System;

    class EncodingSum
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            long result = 0;

           

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (currentChar == '@')
                {
                    Console.WriteLine(result);
                    break;
                }
                else if (char.IsDigit(currentChar))
                {
                    result *= int.Parse(currentChar.ToString());
                }
                else if (char.IsLetter(currentChar))
                {
                    currentChar = char.ToLower(currentChar);
                    int index = currentChar - 'a';
                    result += index;
                }
                else
                {
                    result %= m;
                }


            }

        }
    }
}
