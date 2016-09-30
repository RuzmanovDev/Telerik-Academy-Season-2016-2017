using System;
using log4net;
using log4net.Config;

namespace Log4Net
{
    public class Log4NetExample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Log4NetExample));
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            int[] numbers = new int[20];
            Log.Info("Info logging");
            try
            {
                for (int i = 0; i <= numbers.Length; i++)
                {
                    numbers[i] = i;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Log.Error("We went outside of the array", e);
            }
        }
    }
}
