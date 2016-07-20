using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Kaspichan
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ulong n = ulong.Parse(Console.ReadLine());
            string[] alphabet = new string[256];
            char firstCapitalLetter = 'A';
            char smallLetter = 'a';

            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = firstCapitalLetter.ToString();
                firstCapitalLetter++;
            }

            firstCapitalLetter = 'A';
            for (int i = 26; i < 256; i++)
            {
                alphabet[i] = smallLetter.ToString() + firstCapitalLetter;
                firstCapitalLetter++;
                if (firstCapitalLetter>'Z')
                {
                    firstCapitalLetter = 'A';
                    smallLetter++;
                }
            }


            //foreach (var symbol in alphabet)
            //{
            //    Console.WriteLine(symbol);
            //}
            List<string> answer = new List<string>();
            if (n==0)
            {
                Console.WriteLine("A");
            }
            while (n!=0)
            {
                ulong reminder = n % 256;
                n /= 256;
                answer.Add(alphabet[reminder]);
            }

            answer.Reverse();
            foreach (var number in answer)
            {
                Console.Write(number);
            }
            Console.WriteLine();
           
        }
    }
}
