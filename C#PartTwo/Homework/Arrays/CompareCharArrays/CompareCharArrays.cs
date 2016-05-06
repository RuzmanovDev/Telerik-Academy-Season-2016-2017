namespace CompareCharArrays
{
    using System;

    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();

            char[] firstSymbols = firstLine.ToCharArray();
            char[] secondSybols = secondLine.ToCharArray();

            if (firstSymbols.Length > secondSybols.Length)
            {
                Console.WriteLine(">");
            }
            else if (firstSymbols.Length < secondSybols.Length)
            {
                Console.WriteLine("<");
            }
            else
            {
                for (int i = 0; i < firstSymbols.Length; i++)
                {
                    if (firstSymbols[i]>secondSybols[i])
                    {
                        Console.WriteLine(">");
                        return;
                    }
                    else if (firstSymbols[i]<secondSybols[i])
                    {
                        Console.WriteLine("<");
                        return;
                    }
                }

                Console.WriteLine("=");
            }

        }
    }
}
