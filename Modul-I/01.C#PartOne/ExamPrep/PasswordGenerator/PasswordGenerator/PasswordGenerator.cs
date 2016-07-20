using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    class PasswordGenerator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            List<string> result = new List<string>();


            //generate first digit
            for (int firstDigit = 1; firstDigit < n; firstDigit++)
            {
                for (int secondDigit = 1; secondDigit < n; secondDigit++)
                {
                    for (int thirdSymbol = 0; thirdSymbol < l; thirdSymbol++)
                    {
                        for (int fourthSymbol = 0; fourthSymbol < l; fourthSymbol++)
                        {
                            for (int lastSymbol = 1; lastSymbol <= n; lastSymbol++)
                            {
                                if (lastSymbol > firstDigit && lastSymbol > secondDigit)
                                {
                                    string word = firstDigit.ToString() + secondDigit.ToString() + (char)(thirdSymbol + 97) + (char)(fourthSymbol + 97) + lastSymbol.ToString() + " ";
                                    if (!result.Contains(word))
                                    {
                                        result.Add(word);
                                    }

                                }
                            }

                        }

                    }
                }
            }

            foreach (var num in result)
            {
                Console.Write(num);
            }
        }
    }
}
