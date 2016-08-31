using System;

public class Task5
{
    public static void Main(string[] args)
    {
        uint head = uint.Parse(Console.ReadLine());
        uint numberOfCombs = uint.Parse(Console.ReadLine());

        int maxOnesCount = int.MinValue;
        uint result = 0;

        for (int i = 0; i < numberOfCombs; i++)
        {
            uint currentComb = uint.Parse(Console.ReadLine());
            int onesCount = 0;
            if ((head & currentComb) == 0)
            {
                for (int p = 31; p >= 0; p--)
                {
                    int mask = 1 << p;
                    int numberAndMask = (int)currentComb & mask;
                    int bit = numberAndMask >> p;

                    if (bit == 1)
                    {
                        onesCount++;
                    }
                }
            }

            if (maxOnesCount < onesCount)
            {
                maxOnesCount = onesCount;
                result = currentComb;
            }
        }

        Console.WriteLine(result);
    }
}
