using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2SummOfStrings
{
    class SumOfStrings
    {
        static void Main(string[] args)
        {


            int lines = int.Parse(Console.ReadLine());
            long sumOfLetters = 0;
            long sumOfDigits = 0;
            long sumOfSpecialChar = 0;
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                
                foreach (var symbol in input)
                {
                    // (symbol >= (char)65 && symbol <= (char)90) || (symbol >= (char)97 && symbol <= (char)122)
                    if (char.IsLetter(symbol))
                    {

                        char currentSymbol = char.ToLower(symbol);
                        sumOfLetters += (currentSymbol - 'a' + 1) * 10;

                    }
                    else if (char.IsDigit(symbol))
                    {
                        sumOfDigits += (symbol - '0') * 20;
                    }
                    else if(!char.IsWhiteSpace(symbol))
                    {
                        sumOfSpecialChar += 200;
                    }

                }
            }
            Console.WriteLine(sumOfLetters);
            Console.WriteLine(sumOfDigits);
            Console.WriteLine(sumOfSpecialChar);
        }

    }
}
