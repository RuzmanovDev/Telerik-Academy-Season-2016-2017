using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreasingAbsoluteDifference
{
    class IncreasingAbsoluteDifference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long[] nums = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
               
                bool condition = true;
                for (int j = 2; j < nums.Length; j++)
                {
                    long lastDiff = Math.Abs(nums[j-2] - nums[j - 1]);
                    long currentDiff = Math.Abs(nums[j - 1] - nums[j]);

                    long absDif = Math.Abs(diff - prevDeif);
                    if (!((absDif == 1 || absDif == 0) && diff >= prevDeif))
                    {
                        condition = false;
                        break;
                    }
                }

                if (condition)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }
    }
}
