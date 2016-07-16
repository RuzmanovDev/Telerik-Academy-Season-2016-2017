using System;

    class Program
    {
        static void Main()
        {
            long N = long.Parse(Console.ReadLine());
            //string num = Console.ReadLine();
            ;
            long sum=0;
            long oddSum=0;
            string num = N.ToString() ;
            for (int i = 0; i < num.Length; i++)
            {
                
                if (num[i]%2==0)
                {
                    sum += num[i]-'0';

                }
                else if (num[i]%2>0)
                {
                    oddSum += num[i] - '0';
  
                }
                

             }
            if (sum > oddSum)
            {
                Console.WriteLine("right {0} ", sum);
            }
            else if (sum < oddSum)
            {
                Console.WriteLine("left {0} ", oddSum);


            }
            else if (sum==oddSum)
            {
                Console.WriteLine("straight {0}",sum);
            }
        

        }
    }
