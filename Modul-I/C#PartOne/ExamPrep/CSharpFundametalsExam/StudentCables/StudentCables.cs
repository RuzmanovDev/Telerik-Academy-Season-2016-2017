using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCables
{
    class StudentCables
    {
        static void Main(string[] args)
        {
            int numOfCables = int.Parse(Console.ReadLine());
            int[] cableLength = new int[numOfCables];
            string[] measure = new string[numOfCables];

            int sumCableLength = 0;
            int links = 0;

            for (int i = 0; i < numOfCables; i++)
            {

                cableLength[i] = int.Parse(Console.ReadLine());
                measure[i] = Console.ReadLine();
                if (measure[i].Equals("meters"))
                {
                    cableLength[i] *= 100;
                }
                if (cableLength[i] < 20)
                {
                    cableLength[i] = 0;
  
                }
            }

            foreach (var cable in cableLength)
            {
                sumCableLength += cable;
                if (cable!=0)
                {
                    links++;
                    
                }
            }

            sumCableLength = sumCableLength - (3 * (links-1));
            int studentCables = sumCableLength / 504;
            int reminder = sumCableLength - (studentCables * 504);
            Console.WriteLine(studentCables) ;
            Console.WriteLine(reminder);
        }
    }
}
