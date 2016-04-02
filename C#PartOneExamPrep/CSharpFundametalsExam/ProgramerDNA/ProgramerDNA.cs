using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramerDNA
{
    class ProgramerDNA
    {

        static void Main(string[] args)
        {
            int chainLength = int.Parse(Console.ReadLine());
            int startSymbol = 65;
            int rowNum = chainLength - 1;

            for (int rows = 0; rows < chainLength; rows++)
            {
                for (int cols = 3; cols < 7; cols++)
                {
                    Console.WriteLine(startSymbol);
                }
            }

            
        }
    }
}


