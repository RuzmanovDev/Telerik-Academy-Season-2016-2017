using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tribonachi
{
    static void Main(string[] args)
    {
        long firstNumber = long.Parse(Console.ReadLine());
        long secondNumber = long.Parse(Console.ReadLine());
        long thirdNumber = long.Parse(Console.ReadLine());

        long numberOfLines = long.Parse(Console.ReadLine()) -2 ;
        int counter = 1;
        int newLineCouter = 3;
        long stop = 0;

        Console.WriteLine(firstNumber);
        Console.Write(secondNumber+" ");
        Console.WriteLine(thirdNumber);
        while (stop<numberOfLines)
        {
            long nextNumber = firstNumber + secondNumber + thirdNumber;
            firstNumber = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = nextNumber;
            Console.Write(nextNumber+" ");
            counter++;
            if (counter>newLineCouter)
            {
                Console.WriteLine();
                newLineCouter = counter;
                counter = 1;
                stop++;
            }
        }
            

        

    }
}
