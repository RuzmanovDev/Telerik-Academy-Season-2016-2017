using System;
using System.Numerics;

class secrets
{
    static void Main()
    {
        //input
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        
        BigInteger digit = n;
        BigInteger[] numbers = new BigInteger[400];
        BigInteger specialSUm = 0;
        BigInteger counter = 0;
        BigInteger digitResult = n;
        //count the digits -> for{}
        if (n < 0 || digit<0)
        {
            n *= -1;
            digit *= -1;

        }
        while (n > 0)
        {
            n /= 10;
            counter++;

        }

        //find the secret sum
        for (int i = 1; i <= counter; i++)
        {
            numbers[i] = digit % 10;
            digit /= 10;

            if (i % 2 == 0)
            {
                specialSUm += (numbers[i] * numbers[i]) * i;
            }
            else
            {
                specialSUm += numbers[i] * i * i;
            }
        }
        Console.WriteLine(specialSUm);

        //find the Alpha-sequence
        BigInteger sequenceLendth = specialSUm % 10;
        BigInteger R = specialSUm % 26;
        BigInteger firstLetter = R + 1;
        if (sequenceLendth == 0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", digitResult);
        }
        else
        {
            for (int i = 0; i < sequenceLendth; i++)
            {
                switch ((int)firstLetter)
                {
                    case 1: Console.Write("A"); ; break;
                    case 2: Console.Write("B"); ; break;
                    case 3: Console.Write("C"); ; break;
                    case 4: Console.Write('D'); ; break;
                    case 5: Console.Write('E'); ; break;
                    case 6: Console.Write('F'); ; break;
                    case 7: Console.Write("G"); ; break;
                    case 8: Console.Write("H"); ; break;
                    case 9: Console.Write("I"); ; break;
                    case 10: Console.Write("J"); ; break;
                    case 11: Console.Write("K"); ; break;
                    case 12: Console.Write("L"); ; break;
                    case 13: Console.Write("M"); ; break;
                    case 14: Console.Write("N"); ; break;
                    case 15: Console.Write("O"); ; break;
                    case 16: Console.Write("P"); ; break;
                    case 17: Console.Write("Q"); ; break;
                    case 18: Console.Write("R"); ; break;
                    case 19: Console.Write("S"); ; break;
                    case 20: Console.Write("T"); ; break;
                    case 21: Console.Write("U"); ; break;
                    case 22: Console.Write("V"); ; break;
                    case 23: Console.Write("W"); ; break;
                    case 24: Console.Write("X"); ; break;
                    case 25: Console.Write("Y"); ; break;
                    case 26: Console.Write("Z"); ; break;
                    default: break;

                }
                firstLetter++;
                if (firstLetter > 26)
                {
                    firstLetter = 1;

                }

            }
            Console.WriteLine();
        }
    }
}

