namespace De_cat_coding
{
    using System;
    using System.Linq;

    class DeCatCoding
    {
        static ulong ConvertToDecimal(string numbers)
        {
            ulong result = 0;
            foreach (var digit in numbers)
            {
                result = (ulong)(digit - 'a') + result * 21;
            }
            return result;
        }
        static string ConvertTo26(ulong number)
        {
            string converted = string.Empty;
            do
            {
                char digit = (char)('a' + (number % 26));
                converted = digit + converted;
                number /= 26;
            } while (number != 0);

            return converted;
        }
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(t => ConvertTo26(ConvertToDecimal(t))).ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
