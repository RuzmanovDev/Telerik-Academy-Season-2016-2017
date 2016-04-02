using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.TextToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            int result = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '@')
                {
                    break;
                }
                if (text[i]>='0' && text[i]<='9')
                {
                    result *= text[i] - '0';
                }
                else if (text[i] >= 'a' && text[i] <='z')
                {
                    result += text[i] - 'a';
                }
                else if (text[i]>='A' && text[i]<='Z')
                {
                    result += text[i] - 'A';
                }
               
                else
                {
                    result %= m;
                }
            }
            Console.WriteLine(result);
        }
    }
}
