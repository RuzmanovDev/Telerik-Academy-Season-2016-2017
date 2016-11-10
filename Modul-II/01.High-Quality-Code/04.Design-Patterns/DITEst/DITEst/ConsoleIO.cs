using System;

namespace DITEst
{
    public class ConsoleIO : IIOProvider
    {
        public string Read()
        {
           return  Console.ReadLine();
        }

        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
