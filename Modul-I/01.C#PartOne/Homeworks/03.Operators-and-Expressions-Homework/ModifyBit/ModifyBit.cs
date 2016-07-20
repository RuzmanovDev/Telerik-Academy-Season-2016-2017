namespace ModifyBit
{
    using System;

    class ModifyBit
    {
        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            ulong bit = ulong.Parse(Console.ReadLine());
            ulong mask;
            ulong result = 0;

            if (bit == 1)
            {
                mask = (ulong)1 << position;
                result = number | mask;
            }
            else
            {
                mask = ~((ulong)1 << position);
                result = number & mask;
            }
            Console.WriteLine(result);
        }
    }
}
