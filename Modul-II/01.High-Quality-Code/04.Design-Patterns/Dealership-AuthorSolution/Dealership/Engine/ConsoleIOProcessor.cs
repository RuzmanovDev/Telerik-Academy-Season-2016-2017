using System;

namespace Dealership.Engine
{
    public class ConsoleIOProcessor : IInputOutputProcessor
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}