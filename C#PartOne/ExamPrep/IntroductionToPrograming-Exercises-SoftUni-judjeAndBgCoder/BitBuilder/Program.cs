using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number = uint.Parse(Console.ReadLine());
            List<char> numberAsList = Convert.ToString(number, 2).PadLeft(32, '0').ToCharArray().ToList();

            Console.WriteLine(string.Join(" ", numberAsList));

            int position = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "quit")
            {
                if (command == "flip")
                {


                    if (command == "remove")
                    {

                    }
                    if (command == "insert")
                    {

                    }

                    command = Console.ReadLine();
                    if (command == "quit")
                    {
                        break;
                    }



                }

            }
        }
    }
}