using System;


    class Program
    {
        static void Main()
        {
            long a =  long.Parse(Console.ReadLine());
            long b =  long.Parse(Console.ReadLine());
            long c =  long.Parse(Console.ReadLine());
            long d =  long.Parse(Console.ReadLine());
            long denominator = d * b;
            long nominator = a * d + c * b;
            
            
            
            decimal result = (decimal)a / (decimal)b + (decimal)c / (decimal)d;
           
            if (result >=1)
            {
                Console.WriteLine((long)result);

            }

            else
            {
                Console.WriteLine("{0:f22}", result);
            }
            Console.WriteLine("{0}/{1}", nominator, denominator);
        }
    }

