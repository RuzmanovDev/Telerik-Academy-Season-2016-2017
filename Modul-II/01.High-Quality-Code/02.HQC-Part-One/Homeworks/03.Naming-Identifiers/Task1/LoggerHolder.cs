using System;

namespace Task1
{
    public class LoggerHolder
    {
       private const int MaxCount = 6;

        public class BooleanConsoleLogger
        {
            public void PrintBoolAsString(bool value)
            {
                string valueAsString = value.ToString();

                Console.WriteLine(valueAsString);
            }
        }
    }
}
