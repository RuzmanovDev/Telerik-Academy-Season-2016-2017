using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ',',';',':','.',
                '!','(',')','"','/','\\','[',']',' ','\'' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> upperCase = new List<string>();
            List<string> mixedCase = new List<string>();
            List<string> lowerCase = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string currentWord = input[i];
                bool isMixed = false;
                bool isCapital = false;
                bool isLower = false;
                for (int j = 0; j < currentWord.Length; j++)
                {
                    isCapital = false;
                    isLower = false;
                    char currentSymbol = currentWord[j];
                    if (!char.IsLetter(currentSymbol))
                    {
                        mixedCase.Add(currentWord);
                        break;
                    }
                    if (char.IsLetter(currentSymbol) && char.IsUpper(currentSymbol))
                    {
                        isCapital = true;
                    }
                    if (isCapital && j < currentWord.Length - 2)
                    {
                        if (char.IsLower(currentWord[j + 1]))
                        {
                            isMixed = true;
                            break;
                        }

                    }
                    if (char.IsLetter(currentSymbol) && char.IsLower(currentSymbol))
                    {
                        isLower = true;
                    }

                    if (isLower && j < currentWord.Length - 2)
                    {
                        if (char.IsUpper(currentWord[j + 1]))
                        {
                            isMixed = true;
                            break;
                        }

                    }


                }
                if (isMixed)
                {
                    mixedCase.Add(currentWord);
                }
                else if (isCapital)
                {
                    upperCase.Add(currentWord);
                }
                else if (isLower)
                {
                    lowerCase.Add(currentWord);
                }
            }
            Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCase));


        }
    }
}
