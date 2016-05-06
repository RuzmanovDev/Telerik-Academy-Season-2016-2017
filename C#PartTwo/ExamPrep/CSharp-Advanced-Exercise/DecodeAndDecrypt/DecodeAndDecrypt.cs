namespace DecodeAndDecrypt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class DecodeAndDecrypt
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(Encode(Console.ReadLine()));

            string cypherText = Console.ReadLine();
            int legthOfCypher = cypherText[cypherText.Length - 1] - '0';
            cypherText = cypherText.Substring(0, cypherText.Length - 1);
            cypherText = Encode(cypherText);

            string cypher = cypherText.Substring(cypherText.Length - legthOfCypher);
            cypherText = cypherText.Substring(0, cypherText.Length - cypher.Length);

            // Console.WriteLine(cypher);
            // Console.WriteLine(cypherText);
            Console.WriteLine(Encrypt(cypherText, cypher.ToString()));


        }
        static string Encrypt(string message, string cypher)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            string result = string.Empty;
            for (int i = 0, j = 0; i < Math.Max(message.Length, cypher.Length); i++, j++)
            {
                int symbolFromMessage = 0;
                int symbolFromCypher = 0;
                int resultCode;
                char codeSymbol;
                if (message.Length > cypher.Length)
                {
                    if (j > cypher.Length - 1)
                    {
                        j = 0;
                    }
                    symbolFromMessage = message[i] - 'A';
                    symbolFromCypher = cypher[j] - 'A';

                    resultCode = (symbolFromMessage ^ symbolFromCypher) + 'A';
                    codeSymbol = (char)resultCode;
                    encryptedMessage.Append(codeSymbol);

                }
                else
                {
                    if (j > message.Length - 1)
                    {
                        j = 0;
                        message = encryptedMessage.ToString();

                        encryptedMessage.Remove(0, message.Length - 1);
                    }
                    symbolFromMessage = message[j] - 'A';
                    symbolFromCypher = cypher[i] - 'A';
                    resultCode = (symbolFromMessage ^ symbolFromCypher) + 'A';
                    codeSymbol = (char)resultCode;
                    encryptedMessage.Append(codeSymbol);
                    // TODO ??? is this even working

                }
            }
            result = encryptedMessage.ToString();
            return result;
        }
        static string Encode(string text)
        {
            StringBuilder runLenghtEncoding = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    string number = string.Empty;
                    while (char.IsDigit(text[i]))
                    {
                        number += text[i];
                        i++;
                    }
                    if (i >= text.Length)
                    {
                        i--;
                    }
                    int num = int.Parse(number);
                    runLenghtEncoding.Append(new string(text[i], num));
                }
                else
                {
                    runLenghtEncoding.Append(text[i]);
                }

            }

            string result = runLenghtEncoding.ToString();
            return result;
        }
    }
}
