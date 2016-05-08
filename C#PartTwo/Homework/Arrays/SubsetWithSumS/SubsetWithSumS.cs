namespace SubsetWithSumS
{
    using System;
    using System.Linq;

    class SubsetWithSumS
    {
        static void Main(string[] args)
        {

           // Bitwise magic ( c & p )
            int[] array = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int S = int.Parse(Console.ReadLine());
            int n = array.Length;

            int subsetsCount = (int)Math.Pow(2, n);
            for (int i = 1; i < subsetsCount; i++)
            {
                int sum = 0;
                int bitsOfI = i;
                for (int j = 0; j < n; j++)
                {
                    if (bitsOfI % 2 == 1)
                    {
                        sum += array[j];
                    }
                    bitsOfI = bitsOfI >> 1;
                }
                if (sum == S)
                {
                    Console.WriteLine("True");
                    return;
                }
            }
            Console.WriteLine("False");
        }



    }
}

