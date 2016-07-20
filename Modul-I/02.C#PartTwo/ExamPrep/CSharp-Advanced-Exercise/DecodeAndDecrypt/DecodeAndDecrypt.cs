namespace DecodeAndDecrypt
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class DecodeAndDecrypt
    {
        const char BaseLetter = 'A';
        static void Main(string[] args)
        {
            // Console.WriteLine(Encode(Console.ReadLine()));

            string cypherText = Console.ReadLine();
            var cypher = new List<int>();
            for (int i = cypherText.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(cypherText[i]))
                {
                    cypher.Add(cypherText[i] - '0');
                }
                else
                {
                    break;
                }
            }
            cypher.Reverse();
            int cypherLength = 0;
            for (int i = 0; i < cypher.Count; i++)
            {
                cypherLength *= 10;
                cypherLength += cypher[i];
            }

            // Console.WriteLine(cypherLength);
            cypherText = cypherText.Substring(0, cypherText.Length - cypher.Count);
            // Console.WriteLine(cypherText);
            cypherText = Encode(cypherText);
            // Console.WriteLine(cypherText);
            // Console.WriteLine(cypherStr);

            string cypherStr = cypherText.Substring(cypherText.Length - cypherLength);
            cypherText = cypherText.Substring(0, cypherText.Length - cypherLength);

            string output = Encrypt(cypherText, cypherStr);
            Console.WriteLine(output);

        }
        static string Encrypt(string cypherText, string cypher)
        {
            StringBuilder messageBuilder = new StringBuilder(cypherText);

            int longer = Math.Max(cypherText.Length, cypher.Length);

            for (int index = 0; index < longer; index++)
            {
                int indexInCypherText = index % cypherText.Length;
                int indexInCypher = index % cypher.Length;

                int charInCypherTextOffset = messageBuilder[indexInCypherText] - BaseLetter;
                int charInCypherOffset = cypher[indexInCypher] - BaseLetter;

                messageBuilder[indexInCypherText] = (char)(BaseLetter + (charInCypherTextOffset ^ charInCypherOffset));
            }

            return messageBuilder.ToString();
        }
        static string Encode(string text)
        {
            StringBuilder runLenghtEncoding = new StringBuilder();
            var count = 0;
            foreach (var ch in text)
            {
                if (char.IsDigit(ch))
                {
                    count *= 10;
                    count += ch - '0';

                }
                else
                {
                    if (count == 0)
                    {
                        runLenghtEncoding.Append(ch);

                    }
                    else
                    {
                        runLenghtEncoding.Append(ch, count);
                        count = 0;
                    }
                }
            }

            string result = runLenghtEncoding.ToString();
            return result;
        }
    }
}
