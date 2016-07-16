namespace BitSwap
{
    using System;

    class BitSwap
    {
        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            ulong mask = 0;

            for (int i = p, j = q; i <= p + k - 1; i++, j++)
            {
                ulong fromBit = GetBitAt(number, i);
                ulong toBit = GetBitAt(number, j);

                if (fromBit == 0 && toBit == 1)
                {
                    mask = ~(1UL << j); //set to 0 
                    number = number & mask;

                    mask = (ulong)1 << i; //set to 1
                    number = number | mask;

                }
                else if (fromBit == 1 && toBit == 0)
                {
                    mask = (ulong)1 << j;
                    number = number | mask;

                    mask = ~(1UL << i);
                    number = number & mask;
                }
            }
            Console.WriteLine(number);

        }
        static ulong GetBitAt(ulong number, int bit)
        {

            ulong mask = (ulong)1 << bit;
            ulong numberAndMask = number & mask;
            ulong resut = numberAndMask >> bit;
            return resut;
        }
    }
}

