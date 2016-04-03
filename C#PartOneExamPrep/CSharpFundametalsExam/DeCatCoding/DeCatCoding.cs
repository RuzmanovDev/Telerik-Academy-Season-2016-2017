using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeCatCoding
{
    class DeCatCoding
    {
        static void Main(string[] args)
        {
            char[] twenyOneAlphabet = new char[21];
            char[] twenySixalphabet = new char[26];
            StringBuilder answer = new StringBuilder();
            char letter = 'a';

            for (int i = 0; i < twenyOneAlphabet.Length; i++)
            {
                twenyOneAlphabet[i] = letter;
                letter++;
            }
            letter = 'a';
            for (int i = 0; i < twenySixalphabet.Length; i++)
            {
                twenySixalphabet[i] = letter;
                letter++;
            }

            string[] input = Console.ReadLine().Split(' ');


            for (int i = 0; i < input.Length; i++)
            {
                string currentWord = input[i];
                int power = currentWord.Length-1;
                long numberInTwentyOne = 0;
                for (int j = 0; j < currentWord.Length; j++)
                {
                    // convert from 21 to docimal
                    numberInTwentyOne += Array.IndexOf(twenyOneAlphabet, currentWord[j]) * (long)Math.Pow(21, power);
                    power--;
                }
                //Console.WriteLine(numberInTwentyOne);
                //convert to 26
                while (numberInTwentyOne>0)
                {
                    long currentNumber = numberInTwentyOne % 26;
                    answer.Append(twenySixalphabet[currentNumber]);
                    numberInTwentyOne /= 26;
                }
                //string reversedWord = answer.ToString().Reverse();
                if (i!= input.Length-1)
                {
                    answer.Append(' ');

                }
              

            }
            string output = answer.ToString();
            string[] reversed = output.Split(' ');

            for (int i = 0; i < reversed.Length; i++)
            {
                string word = reversed[i];
                for (int j = word.Length-1; j >= 0; j--)
                {
                    Console.Write(word[j]);
                }
                Console.Write(' ');
            }
            Console.WriteLine();
           
        }
    }
}
