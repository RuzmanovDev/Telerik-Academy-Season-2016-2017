using System;


namespace DrawCube
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int firstHalf = width - 3;

            Console.Write(new string(' ',width-1));
            Console.WriteLine(new string(':', width));
            Console.Write(new string(' ', width - 2));
            Console.Write(":");
            Console.Write(new string('/',width-2));
            Console.WriteLine(new string(':',2));
            int spaceCount = width - 3;
            for (int i = 0; i < firstHalf; i++)
            {
                int countX = i+1;
                
                Console.Write(new string(' ', spaceCount--));
                Console.Write(":");
                Console.Write(new string('/', width - 2));
                Console.Write(":");
                Console.Write(new string('X', countX));
                Console.WriteLine(":");
                
            }
            Console.Write(new string(':',width));
            Console.Write(new string('X',width-2));
            Console.WriteLine(":");
            int xCount = width - 3;
            for (int i = 0; i < width-2; i++)
            {
                Console.Write(":");
                Console.Write(new string(' ', width-2));
                Console.Write(":");
                Console.Write(new string('X', xCount--));
                Console.WriteLine(":");
            }
            Console.WriteLine(new string(':', width));
        }
    }
}
