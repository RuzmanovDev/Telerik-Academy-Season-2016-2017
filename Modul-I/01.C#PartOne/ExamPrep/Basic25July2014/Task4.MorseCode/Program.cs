using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.MorseCode
{
    class MorseCode
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            string[] morseCodeEncodin = { "-----", ".----", "..---", "...--", "....-", "....." };

            int nSum = 0;

            while (n != 0)
            {
                nSum += n % 10;
                n /= 10;
            }
            //Console.WriteLine(nSum);
            bool doesExist = false;
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    for (int k = 0; k <= 5; k++)
                    {
                        for (int l = 0; l <= 5; l++)
                        {
                            for (int m = 0; m <= 5; m++)
                            {
                                for (int p = 0; p <= 5; p++)
                                {
                                    if (i * j * k * l * m * p == nSum)
                                    {
                                        Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|", morseCodeEncodin[i], morseCodeEncodin[j], morseCodeEncodin[k],
                                            morseCodeEncodin[l], morseCodeEncodin[m], morseCodeEncodin[p]);
                                        doesExist = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!doesExist)
            {
                Console.WriteLine("No");
            }

            
        }
    }
}
