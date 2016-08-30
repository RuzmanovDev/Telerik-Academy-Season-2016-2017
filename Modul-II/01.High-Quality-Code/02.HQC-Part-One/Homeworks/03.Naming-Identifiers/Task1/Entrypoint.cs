namespace Task1
{
    public class Entrypoint
    {
        public static void Main()
        {
            var consolePrinter = new LoggerHolder.BooleanConsoleLogger();

            consolePrinter.PrintBoolAsString(true);
        }
    }
}
