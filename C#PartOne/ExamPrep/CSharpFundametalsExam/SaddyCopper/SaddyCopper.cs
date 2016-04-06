using System;
using System.Collections.Generic;
using System.Numerics;

namespace SaddyCopper
{
    class SaddyCopper
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //BigInteger number = BigInteger.Parse(input);
            List<char> inputAsArray = new List<char>(input.ToCharArray());
            List<ulong> evenSums = new List<ulong>();
            BigInteger productOfEvenSums = 1;
            byte transformationsCounter = 0;

            while (true)
            {
                inputAsArray.RemoveAt(inputAsArray.Count - 1);

                if (inputAsArray.Count == 0)
                {
                    foreach (var evenSum in evenSums)
                    {
                        productOfEvenSums *= BigInteger.Parse(evenSum.ToString());
                    }
                    transformationsCounter++;
                    inputAsArray = new List<char>(productOfEvenSums.ToString().ToCharArray());
                    if (inputAsArray.Count == 1 || transformationsCounter == 10)
                    {
                        break;
                    }
                    evenSums.Clear();
                    productOfEvenSums = 1;
                   
                    continue;
                }

                ulong currentEvenSum = 0;
                for (int i = 0; i < inputAsArray.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        currentEvenSum += ulong.Parse(inputAsArray[i].ToString());
                    }
                }
                evenSums.Add(currentEvenSum);
            }

            if (transformationsCounter < 10)
            {
                Console.WriteLine(transformationsCounter);
                Console.WriteLine(inputAsArray[0]);
              
            }
            else
            {

                Console.WriteLine(string.Join("", inputAsArray));

            }



        }
    }
}
