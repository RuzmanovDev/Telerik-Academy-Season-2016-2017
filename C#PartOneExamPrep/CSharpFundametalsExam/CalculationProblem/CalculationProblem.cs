using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationProblem
{
    class CalculationProblem
    {
        static void Main(string[] args)
        {

            //declare dict ==> 'a'==0 etc..
            Dictionary<char, int> decription = new Dictionary<char, int>();

            for (int i = 0, j = 97; i < 23 && j < 123; i++, j++)
            {
                decription.Add((char)j, i);
            }

            string input = Console.ReadLine();
            int output = Encrypt(input, decription);


            string text = Decrypt(output);
            Console.WriteLine("{0} = {1}", text, output);


        }
        static int Encrypt(string input, Dictionary<char, int> decription)
        {

            string[] code = input.Split(' ');   
            int output = 0;

            for (int j = 0; j < code.Length; j++)
            {
                int answer = 0;
                int length = code[j].Length;

                for (int power = length - 1, i = 0; i < length && power > -1; i++)
                {
                    string temp = code[j];

                    if (decription.ContainsKey(temp[i]) == true)
                    {
                        int digit = int.Parse(decription[temp[i]].ToString());
                        double number = digit * (int)Math.Pow(23, (int)power);
                        power--;
                        answer += (int)number;
                    }

                }
                output += answer;
            }
            return output;
        }
        static string Decrypt(int number)
        {
            string resultStr = string.Empty;
            int forNumerical = number;
            while (forNumerical > 0)
            {
                char ch = (char)((forNumerical % 23) + 'a');
                resultStr = ch.ToString() + resultStr;
                forNumerical /= 23;
            }
            return resultStr;
        }

    }
}

