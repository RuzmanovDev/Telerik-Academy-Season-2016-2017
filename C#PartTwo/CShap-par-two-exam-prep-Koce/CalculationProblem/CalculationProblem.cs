namespace CalculationProblem
{
    using System;
    using System.Linq;

    class CalculationProblem
    {
        // read input
        // convert every number to it's decimal value
        // sum all the numbers 
        static int MeowToDec(string meow)
        {
            int result = 0;

            foreach (var digit in meow)
            {
                result = (digit - 'a') + result * 23;
            }
            return result;
        }
        static string DecimalToMeow(int dec)
        {
            var result = string.Empty;

            do
            {
                char digitValue = (char)('a' + (dec % 23));
                result = digitValue + result;
                dec /= 23;

            } while (dec > 0);


            return result;
        }
        static void Main()
        {
            var catNumbers = Console.ReadLine().Split(' ').Select(MeowToDec).ToArray();
            var sum = catNumbers.Sum();

            var answer = DecimalToMeow(sum) + " = " + sum;
            Console.WriteLine(answer);
        }
    }
}
