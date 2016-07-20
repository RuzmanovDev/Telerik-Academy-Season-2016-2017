namespace StrangelandNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class StrangelandNumbers
    {
        static void Main(string[] args)
        {
            string[] alphabet = { "f", "bIN", "oBJEC", "mNTRAVL", "lPVKNQ", "pNWE", "hT" };
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            List<int> decimalValues = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                string currentWord = input[i].ToString();
                sb.Append(currentWord);

                if (alphabet.Contains(sb.ToString()))
                {
                    decimalValues.Add(Array.IndexOf(alphabet, sb.ToString()));
                    sb.Clear();
                }
            }
            long result = 0;

            for (int i = 0; i < decimalValues.Count; i++)
            {
                result *= 7;
                result += decimalValues[i];
            }
            Console.WriteLine(result);
        }
    }
}
