using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<int> sums = new List<int>();
            int productOfSums = 1;
            int count = 0;
            while (true)
            {
               
                int newNumber = number / 10;
                if (newNumber==0)
                {
                    number = int.Parse(Console.ReadLine());
                    continue;
                }
                string numberAsStr = newNumber.ToString();
                
                int sum = 0;
                for (int i = 0; i < numberAsStr.Length; i++)
                {
                    if (i%2==0)
                    {
                       sum += int.Parse(numberAsStr[i].ToString());
                        sums.Add(sum);
                    }
                }
                foreach (var nums in sums)
                {
                    productOfSums *= nums;
                }
                number = productOfSums;
                count++;
            }
        }
    }
}
