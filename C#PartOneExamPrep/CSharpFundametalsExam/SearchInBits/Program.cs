using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbertoSearch = int.Parse(Console.ReadLine());
            string patter = Convert.ToString(numbertoSearch, 2).PadLeft(4, '0');

            int numberOfLines = int.Parse(Console.ReadLine());


            int totalCount = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                long nextNumber = long.Parse(Console.ReadLine());
                string currentNumber = Convert.ToString(nextNumber, 2).PadLeft(30, '0');
                int count = 0;
                for (int index = 0; index < currentNumber.Length - 3; index++)
                {
                    string checkingPattern = currentNumber.Substring(index, 4);
                    for (int j = 0; j < patter.Length; j++)
                    {
                        if (patter[j] == checkingPattern[j])
                        {
                            count++;
                        }
                        else
                        {
                            count = 0;
                            break;
                        }
                        if (count == 4)
                        {
                            totalCount++;
                            break;
                        }
                       
                    }

                }
            }
            Console.WriteLine(totalCount);
        }
    }
}
