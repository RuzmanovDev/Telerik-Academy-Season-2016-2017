using System;
using System.Collections.Generic;
using System.Linq;
class drunkenNumbers
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        int mitko = 0;
        int vladko = 0;


        for (int i = 0; i < n; i++)
        {
            int roundInfo = int.Parse(Console.ReadLine());

            int digits = 0;
            
            if (roundInfo < 0)
            {
                roundInfo *= -1;
            }
            int tempRoundInfo = roundInfo;
            
            while (tempRoundInfo > 0)
            {
                tempRoundInfo /= 10;
                digits++;

            }
            
            
            // odd or even
            if (digits % 2 == 0) //even
            {
                for (int j = 0; j < digits / 2; j++)
                {
                    vladko += (roundInfo % 10);
                    roundInfo /= 10;
                }
                for (int j = 0; j < digits / 2; j++)
                {
                    mitko += (roundInfo % 10);
                    roundInfo /= 10;
                }
            }
            else
            {
                for (int j = 0; j < digits / 2; j++)
                {
                    vladko += (roundInfo % 10);
                    roundInfo /= 10;
                }
                int middle = (roundInfo % 10);
                vladko += middle;
                mitko += middle;
                roundInfo /= 10;
                for (int j = 0; j < digits / 2; j++)
                {
                    mitko += (roundInfo % 10);
                    roundInfo /= 10;
                }
            }

        }
        if (vladko>mitko)
        {
            Console.WriteLine("V {0}",vladko-mitko);
        }
        else if (mitko>vladko)
        {
            Console.WriteLine("M {0}",mitko-vladko);
        }
        else if (vladko==mitko)
        {
             
            Console.WriteLine("No {0}", mitko+vladko);
        
        }
       

    }

}

