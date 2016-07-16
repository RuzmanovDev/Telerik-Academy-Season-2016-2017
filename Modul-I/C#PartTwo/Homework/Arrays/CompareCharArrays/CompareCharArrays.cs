namespace CompareCharArrays
{
    using System;

    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();

            for (int i = 0; i < Math.Min(firstLine.Length,secondLine.Length); i++)
            {
                if (firstLine[i] > secondLine[i])
                {
                    Console.WriteLine(">");
                    return;
                }
                else if (firstLine[i] < secondLine[i])
                {
                    Console.WriteLine("<");
                    return;
                }
            }

            if (firstLine.Length == secondLine.Length)
            {
                Console.WriteLine("=");
            }
            else if (firstLine.Length < secondLine.Length)
            {
                Console.WriteLine("<");
            }
            else if (firstLine.Length > secondLine.Length)
            {
                Console.WriteLine(">");
            }
        }
    }
}
