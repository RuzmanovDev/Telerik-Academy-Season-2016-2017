namespace MultiverseCommunication
{
    using System;
    using System.Collections.Generic;

    class MultiverseCommunication
    {
        static void Main(string[] args)
        {
            string[] alphabet = { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
            long result = 0;
            string input = Console.ReadLine();
            List<string> digit = new List<string>();
            // split the word into 3s
            for (int i = 0; i < input.Length - 2; i += 3)
            {
                string currentDigit = input.Substring(i, 3);
                digit.Add(currentDigit);

            }
            digit.Reverse(); // to use the proper index when converting
            // TODO: logic

            for (int i = 0; i < digit.Count; i++)
            {
                result += Array.IndexOf(alphabet, digit[i]) * (long)Math.Pow(13, i);
            }

            // print the result
            Console.WriteLine(result);
        }
    }
}
