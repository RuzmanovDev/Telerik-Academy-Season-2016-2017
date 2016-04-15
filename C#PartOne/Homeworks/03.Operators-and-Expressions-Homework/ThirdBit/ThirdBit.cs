namespace ThirdBit
{
    using System;

    class ThirdBit
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int mask = 1 << 3;
            //string str = Convert.ToString(mask,2).PadLeft(32,'0');
            int numberAndMask = number & mask;
           // str = Convert.ToString(numberAndMask, 2).PadLeft(32, '0');
            int bit = numberAndMask >> 3;
           // str = Convert.ToString(bit, 2).PadLeft(32, '0');
            Console.WriteLine(bit);




        }
    }
}
