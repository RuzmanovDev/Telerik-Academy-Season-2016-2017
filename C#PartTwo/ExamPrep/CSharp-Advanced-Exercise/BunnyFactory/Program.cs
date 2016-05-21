using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BunnyFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BigInteger> cages = new List<BigInteger>();
           
            int cycles = 1;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }
                BigInteger num = BigInteger.Parse(command);
                cages.Add(num);
            }

            // multiplication proccess
            while (true)
            {
                BigInteger sum = 0;
                int i = 0;

                while (i < cycles) // sum item depending on the cycle 
                {
                    sum += cages[i];
                    i++;
                }

                BigInteger nextSum = 0;
                BigInteger product = 1;

                // TODO: 40/100

                BigInteger multiplicationLoop = i + sum;
                if (multiplicationLoop > cages.Count - 1)
                {
                    break;
                }
                while (i < multiplicationLoop)
                {
                    nextSum += cages[i];
                    product *= cages[i];
                    i++;
                }

                // remove elements and concatinate other
                i--;

                cages.RemoveRange(0, cages.Count - (cages.Count - 1 - i));
                // appends result
                while (product != 0)
                {
                    BigInteger currentDigit = product % 10;
                    cages.Insert(0, currentDigit);
                    product /= 10;
                }
                // appends result
                while (nextSum != 0)
                {
                    BigInteger currentDigit = nextSum % 10;
                    cages.Insert(0, currentDigit);
                    nextSum /= 10;
                }

                // remove 0 and 1 
                cages.RemoveAll(n => n == 0 || n == 1);
                // end of the first cycle
                cycles++;
                Seperae(cages);
            }

            Console.WriteLine(string.Join(" ", cages));
        }

        private static void Seperae(List<BigInteger> cages)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < cages.Count; i++)
            {
                BigInteger num = cages[i];
                while (num != 0)
                {
                    int residual = (int)(num % 10);
                    sb.Append(residual);
                    num /= 10;
                }
            }

            cages.Clear();
            foreach (var num in sb.ToString())
            {
                cages.Add(BigInteger.Parse(num.ToString()));
            }
        }
    }
}
