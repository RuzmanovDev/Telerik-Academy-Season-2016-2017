namespace SequenceOfBitsArray
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class SequenceOfBitsArray
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                string numberBits = Convert.ToString(number, 2).PadLeft(30, '0');
                sb.Append(numberBits);

            }
            char[] bits = sb.ToString().ToCharArray();

            int maxZeroCounter = int.MinValue;
            int maxOnesCounter = int.MinValue;
            int zeroCounter = 0;
            int onesCounter = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '0')
                {
                    zeroCounter++;
                }
                else 
                {
                    zeroCounter = 0;
                   
                }
                if (zeroCounter > maxZeroCounter)
                {
                    maxZeroCounter = zeroCounter;
                }
                
            }
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '1')
                {
                    onesCounter++;
                }
                else
                {
                    onesCounter = 0;

                }
                if (onesCounter > maxOnesCounter)
                {
                    maxOnesCounter = onesCounter;
                }
            }
            Console.WriteLine(maxOnesCounter);
            Console.WriteLine(maxZeroCounter);
        }
    }
}
