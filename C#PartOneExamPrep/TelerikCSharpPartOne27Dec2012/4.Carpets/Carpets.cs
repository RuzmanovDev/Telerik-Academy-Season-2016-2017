using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Carpets
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());
        int topDots = input / 2 - 1;

        for (int i = 0; i < input/2; i++)
        {
            if (i%2!=0)
            {
                Console.Write(new string('.', topDots));
                Console.Write(" /");
                Console.Write("\\ ");
                Console.Write(new string('.', topDots));
                Console.WriteLine();
                topDots--;

               

               
            }
            Console.Write(new string('.', topDots));
            Console.Write("/");
            Console.Write("\\");
            Console.Write(new string('.', topDots));
            Console.WriteLine();
            topDots--;
        }
        
       
        


    }
}

