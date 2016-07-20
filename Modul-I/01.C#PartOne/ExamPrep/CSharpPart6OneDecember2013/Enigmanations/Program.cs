using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigmanations
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == '(')
                {
                    double firstNumber = double.Parse(input[i + 1].ToString());

                    while (currentChar != ')')
                    {
                        currentChar = input[i + 1];

                        double seconNumber = double.Parse(input[i + 3].ToString());
                        char sign = input[i + 2];
                        switch (sign)
                        {
                            case '+': result = firstNumber + seconNumber; break;
                            case '-': result = firstNumber - seconNumber; break;
                            case '*': result = firstNumber * seconNumber; break;
                            case '/': result = firstNumber / seconNumber; break;
                            case '%': result = firstNumber % seconNumber; break;

                        }

                    }


                }
            }
        }

    }

}
