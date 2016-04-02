using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem5.StudentsToStudentsAndBitsToBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger[] numbersFromInput = new BigInteger[n];
            StringBuilder sb = new StringBuilder();
            string[] numbersBits = new string[n];

            for (int i = 0; i < numbersFromInput.Length; i++)
            {
                numbersFromInput[i] = BigInteger.Parse(Console.ReadLine());

            }
            for (int i = 0; i < numbersFromInput.Length; i++)
            {
                string str = Convert.ToString((long)numbersFromInput[i], 2).PadLeft(64, '0');
                numbersBits[i] = str;

            }

            for (int i = 0; i < numbersBits.Length; i++)
            {
                string bits = numbersBits[i];
                for (int bit = 34; bit < bits.Length; bit++)
                {
                    sb.Append(bits[bit]);

                }
            }


            string sequenceOfBits = sb.ToString();

            int maxSequenceOfZeros = 0;

            int maxSequenceOfOnes = 0;
            int sequenceOfZeroes = 0;
            int sequenceOfOnes = 0;

            for (int i = 0; i < sequenceOfBits.Length; i++)
            {
                if (sequenceOfBits[i] == '0')
                {
                    sequenceOfZeroes++;
                    sequenceOfOnes = 0;
                    if (sequenceOfOnes>=maxSequenceOfOnes)
                    {
                        maxSequenceOfOnes = sequenceOfOnes;
                    }
                    
                    if (sequenceOfZeroes >= maxSequenceOfZeros)
                    {
                        maxSequenceOfZeros = sequenceOfZeroes;

                    }
                }
                else
                {
                    sequenceOfZeroes = 0;
                    sequenceOfOnes++;
                    if (sequenceOfZeroes >= maxSequenceOfZeros)
                    {
                        maxSequenceOfZeros = sequenceOfZeroes;
                        
                    }
                    if (sequenceOfOnes >= maxSequenceOfOnes)
                    {
                        maxSequenceOfOnes = sequenceOfOnes;
                    }
                   

                }

            }

            Console.WriteLine(maxSequenceOfZeros);
            Console.WriteLine(maxSequenceOfOnes);
           
        }
    }

}
