namespace SymbolToNumbers
{
    using System;

    class SymbolToNumbers
    {
        static void Main(string[] args)
        {
            int secretNumber = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            double result = 0;
            double secondResult = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (currentChar=='@')
                {
                    break;
                }
                else if (Char.IsLetter(currentChar))
                { 
                    result = (int)currentChar * secretNumber + 1000;
                }
                else if (Char.IsDigit(currentChar))
                {
                    result = currentChar + secretNumber + 500;
                }
                else
                {
                    result = currentChar - secretNumber;
                }
                if (i%2==0)
                {
                    secondResult = result / 100d;
                    Console.WriteLine("{0:F2}", secondResult);
                }
                else
                {
                    secondResult = result * 100;
                    Console.WriteLine("{0}", (int)secondResult);
                 
                }
                
            }
        }
    }
}
