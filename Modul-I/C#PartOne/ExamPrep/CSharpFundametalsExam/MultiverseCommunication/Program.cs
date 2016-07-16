using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var keys = new List<string> { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };

        var input = Console.ReadLine();
        long result = 0;
        for (int i = 0; i < input.Length; i += 3)
        {
            var digitIn13 = input.Substring(i, 3);
            var decimalValue = keys.IndexOf(digitIn13);
            result *= 13;

            result += decimalValue;
        }
        Console.WriteLine(result);


    }

}

