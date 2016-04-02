using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.BitPaths
{
    class BitPaths
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[] arr = new int[4];
            int sum = 0;
            for (int i = 0; i < lines; i++)
            {
                string[] commands = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int position = int.Parse(commands[0]);
                ChangeBit(arr, position);
                for (int j = 1; j < 7; j++)
                {
                   
                    if (commands[j] == "-1")
                    {
                        position--;
                    }
                    else if (commands[j] == "+1")
                    {
                        position++;
                    }
                    ChangeBit(arr, position);
                    string str = string.Concat(arr);
                    sum = sum + Convert.ToInt32(str, 2);

                    
                }
            }
            Console.WriteLine(Convert.ToString(sum, 2));
            Console.WriteLine(sum.ToString("X"));

        }
        static void ChangeBit(int[] arr, int index)
        {
            if (arr[index] == 0)
            {
                arr[index] = 1;
            }
            else
            {
                arr[index] = 0;
            }
        }
    }
}
