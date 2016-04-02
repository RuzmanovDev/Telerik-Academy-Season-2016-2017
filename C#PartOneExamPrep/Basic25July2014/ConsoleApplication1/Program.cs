using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());

            char symbol = 'A';
            int hashTags = size - 2;

            for (int i = 0; i < size / 2; i++)
            {
                int tilda = i;
                Console.Write(new string('~', tilda));
                Console.Write(symbol++);
                if (symbol > 'Z')
                {
                    symbol = 'A';
                }
                Console.Write(new string('#', hashTags));
                hashTags -= 2;
                Console.Write(symbol++);
                Console.WriteLine(new string('~', tilda));
                if (symbol > 'Z')
                {
                    symbol = 'A';
                }
            }
            Console.Write(new string('-', size / 2));
            Console.Write(symbol++);
            if (symbol > 'Z')
            {
                symbol = 'A';
            }
            Console.WriteLine(new string('-', size / 2));
            int bottomTilda = (size - 3) / 2;
            hashTags = 1;
            for (int i = 0; i < size/2; i++)
            {
                Console.Write(new string('~',bottomTilda));
                Console.Write(symbol++);
                if (symbol > 'Z')
                {
                    symbol = 'A';
                }
                Console.Write(new string('#', hashTags));
                hashTags += 2;
                Console.Write(symbol++);
                Console.WriteLine(new string('~', bottomTilda));
                bottomTilda--;
                if (symbol > 'Z')
                {
                    symbol = 'A';
                }
            }
        }
    }
}
