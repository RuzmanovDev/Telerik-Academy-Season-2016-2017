﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodeDecode
{
    class EncodeDecode
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string cipher = Console.ReadLine();

            string encodedText = Encode(text, cipher);
            Console.WriteLine(encodedText);

            // to test if the method iя working i call it again because ^^ = orignal text
            Console.WriteLine(Encode(encodedText, cipher));
        }

        private static string Encode(string text, string cipher)
        {
            StringBuilder encodedText = new StringBuilder();

            // TODO: if cipher or the text have bigger length BOOM
            int forCycleCount = Math.Max(text.Length, cipher.Length);
            for (int i = 0; i < forCycleCount; i++)
            {
                if (i >= text.Length || i >= cipher.Length)
                {
                    i = 0;
                }
                char encodedChar = (char)(text[i] ^ cipher[i]);
                encodedText.Append(encodedChar);
            }

            return encodedText.ToString();
        }
    }
}
