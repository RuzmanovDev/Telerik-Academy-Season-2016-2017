namespace CompareCharArrays
{
    using System;

    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();

            firstLine = firstLine.ToLower();
            secondLine = secondLine.ToLower();

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
            Console.WriteLine("=");
        }

    }
}
