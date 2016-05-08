namespace TwoGirlsOnePath
{
    using System;
    using System.Linq;
    using System.Numerics;

    class TwoGirlsOnePath
    {
        static void Main(string[] args)
        {
            BigInteger[] path = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();

            BigInteger Molly = 0;
            BigInteger Dolly = 0;

            int mollyIndex = 0;
            int dollyIndex = path.Length - 1;
            string winner = string.Empty;

            while (true)
            {
                if (path[mollyIndex] == 0 || path[dollyIndex] == 0)
                {
                    if (path[mollyIndex] == 0 && path[dollyIndex] == 0)
                    {
                        winner = "Draw";
                    }
                    else if (path[mollyIndex] == 0)
                    {
                        winner = "Dolly";
                    }
                    else if (path[dollyIndex] == 0)
                    {
                        winner = "Molly";
                    }

                    Molly += path[mollyIndex];
                    Dolly += path[dollyIndex];
                    break;
                }

                BigInteger mollyValue = path[mollyIndex];
                BigInteger dollyValue = path[dollyIndex];

                if (mollyIndex == dollyIndex)
                {
                    path[mollyIndex] = mollyValue % 2;

                    Molly += mollyValue / 2;
                    Dolly += dollyValue / 2;
                }
                else
                {
                    path[mollyIndex] = 0;
                    path[dollyIndex] = 0;

                    Molly += mollyValue;
                    Dolly += dollyValue;
                }

                mollyIndex = (int)((mollyIndex + mollyValue) % path.Length);
                dollyIndex = (int)((dollyIndex - dollyValue) % path.Length);
                if (dollyIndex < 0)
                {
                    dollyIndex += path.Length;
                }

            }

            Console.WriteLine(winner);
            Console.WriteLine("{0} {1}", Molly, Dolly);
        }
    }
}
