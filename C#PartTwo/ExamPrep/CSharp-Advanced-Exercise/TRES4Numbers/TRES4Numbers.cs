namespace TRES4Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class TRES4Numbers
    {
        static void Main(string[] args)
        {
            string[] digits = { "LON+", "VK-", "*ACAD", "^MIM", "ERIK|", "SEY&", "EMY>>", "/TEL", "<<DON" };
            ulong number = ulong.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine(digits[0]);
                return;
            }

            List<ulong> residuals = new List<ulong>();
            StringBuilder result = new StringBuilder();
            while (number != 0)
            {
                ulong residual = number % 9;
                residuals.Add(residual);

                number /= 9;
            }

            for (int i = residuals.Count - 1; i >= 0; i--)
            {
                int currentDigitIndex = (int)residuals[i];
                string currentDgit = digits[currentDigitIndex];
                result.Append(currentDgit);
            }
           
                Console.WriteLine(result.ToString());
        }
    }
}
