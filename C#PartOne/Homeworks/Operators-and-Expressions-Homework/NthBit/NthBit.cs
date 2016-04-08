namespace NthBit
{
    using System;

    class NthBit
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            int bit = int.Parse(Console.ReadLine());

            int mask = 1 << bit;
            long numberAndMask = number & mask;
            long resut = numberAndMask >> bit;
            Console.WriteLine(resut);
        }
    }
}
