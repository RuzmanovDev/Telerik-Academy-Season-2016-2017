namespace DrunkenNumbersStr
{
    using System;

    public class DrunkenNumbersStr
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int mitkoTotal = 0;
            int vladkoTotal = 0; // could be Macedonian 

            for (int i = 0; i < n; i++)
            {
                string drunkerNumber = Console.ReadLine();
                int x = int.Parse(drunkerNumber);
                if (x < 0)
                {
                    x = -x;
                }

                drunkerNumber = x.ToString();

                if (drunkerNumber.Length % 2 == 0)
                {
                    for (int j = 0; j < drunkerNumber.Length / 2; j++)
                    {
                        mitkoTotal += drunkerNumber[j] - '0';
                    }

                    for (int j = drunkerNumber.Length / 2; j < drunkerNumber.Length; j++)
                    {
                        vladkoTotal += drunkerNumber[j] - '0';
                    }
                }
                else
                {
                    for (int j = 0; j < (drunkerNumber.Length / 2) + 1; j++)
                    {
                        mitkoTotal += drunkerNumber[j] - '0';
                    }

                    for (int j = drunkerNumber.Length / 2; j < drunkerNumber.Length; j++)
                    {
                        vladkoTotal += drunkerNumber[j] - '0';
                    }
                }
            }

            if (mitkoTotal > vladkoTotal)
            {
                Console.WriteLine("M {0}", mitkoTotal - vladkoTotal);
            }
            else if (mitkoTotal < vladkoTotal)
            {
                Console.WriteLine("V {0}", vladkoTotal - mitkoTotal);
            }
            else
            {
                Console.WriteLine("No {0}", vladkoTotal + mitkoTotal);
            }
        }
    }
}
