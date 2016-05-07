namespace SubsetWithSumS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SubsetWithSumS
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sum = int.Parse(Console.ReadLine());

            int usedSum;
            List<int> usedNums = new List<int>();
            List<int> unusedNums = new List<int>();
            bool isFound = false;
            usedNums.Add(numbers[0]);

            unusedNums = numbers.ToList();
            unusedNums.RemoveAt(0);

            usedSum = usedNums.Sum();
            if (usedSum == sum)
            {
                isFound = true;
            }
            while (usedSum != sum)
            {
                if (sum > usedSum)
                {
                    usedNums.Add(unusedNums[0]);
                    unusedNums.RemoveAt(0);
                    usedSum = usedNums.Sum();
                }
                else
                {
                    unusedNums.Add(usedNums[usedNums.Count - 1]);
                    usedNums.RemoveAt(usedNums.Count - 1);
                    usedSum = usedNums.Sum();
                }
            }

            if (usedSum == sum)
            {
                isFound = true;
            }

            if (isFound)
            {
                Console.WriteLine("The sum {0} does  exist in this subset", sum);
            }
            else
            {
                Console.WriteLine("The sum {0} does NOT exist in this subset", sum);
            }




        }
    }
}
