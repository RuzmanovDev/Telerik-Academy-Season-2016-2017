namespace StringLength
{
    using System;

    class StringLength
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            input = input.Replace(@"\", string.Empty);
            if (input.Length == 20)
            {
                Console.WriteLine(input);
            }
            else
            {
                for (int i = input.Length; i < 20; i++)
                {
                    input += '*';
                }
                Console.WriteLine(input);
            }
        }
    }
}