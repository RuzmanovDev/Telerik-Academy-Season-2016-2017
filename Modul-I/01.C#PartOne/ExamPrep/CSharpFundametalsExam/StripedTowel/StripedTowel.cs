using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripedTowel
{
    class StripedTowel
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            
            int height = (int)Math.Floor(width * 1.5);
            string space = ".."; //2 + 3(n-1)

            for (int rows = 0; rows < height; rows++)
            {
                for (int cols = 0; cols < width; cols++)
                {
                    if ((rows + cols) %3==0)
                    {
                        Console.Write('#');
                    }
                    
                    else 
                    {
                        Console.Write('.');
                    }
                    
                   

                }
                Console.WriteLine();

            }
        }
    }
}
