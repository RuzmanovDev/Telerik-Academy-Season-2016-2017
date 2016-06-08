namespace GsmTestClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MobilePhoneDevice;

    public class GsmTestClass
    {
        public static void Main(string[] args)
        {
            GsmTest();
            CallHistoryTest();
        }

        private static void GsmTest()
        {
            Console.WriteLine("------------GsmTest------------");
            Console.WriteLine();

            // Create an array of few instances of the GSM class.
            var lion = new Battery("pesho123", 100, 30, BatteryType.LiIon);
            var gorilla = new Display(5, 6000000);
            var samsung = new Gsm("galaxy s2", "samsung", 400, "Stoyan", lion, gorilla);
            var htc = new Gsm("m8", "HTC", 350, "Dragan", lion, gorilla);
            var sony = new Gsm("xperia z5", "Sony", 500, "Pesho", lion, gorilla);
            var onePlusOne = new Gsm("onePlusOne", "onePlusOne", 600, "Ivan", lion, gorilla);

            var gsmList = new List<Gsm> { samsung, htc, sony, onePlusOne };

            // Display the information about the GSMs in the array.
            Console.WriteLine(string.Join(Environment.NewLine, gsmList));
            Console.WriteLine(Gsm.iPhone4S);
        }

        private static void CallHistoryTest()
        {
            Console.WriteLine("------------Call History Test------------");
            Console.WriteLine();
            var lion = new Battery("pesho123", 100, 30, BatteryType.LiIon);
            var gorilla = new Display(5, 6000000);

            // Create an instance of the GSM class.
            var samsung = new Gsm("galaxy s2", "samsung", 350, "Stoyan", lion, gorilla);

            // Add few calls.
            var call = new Call(DateTime.Now, 190, "089 588 8000");
            var another = new Call(new DateTime(2016, 12, 12), 220, "089 580 0820");
            var yetAnother = new Call(new DateTime(2016, 02, 12), 133, "089 500 8320");

            samsung.AddCall(call);
            samsung.AddCall(another);
            samsung.AddCall(yetAnother);

            // print the list of calls
            IList<Call> listOfCalls = samsung.ListOfCalls;

            // Display the information about the calls.
            Console.WriteLine(string.Join(Environment.NewLine, listOfCalls));

            // calculates the price of total calls
            decimal price = samsung.TotalPriceOfCalls();
            Console.WriteLine(price);
            Console.WriteLine();

            // Remove the longest call from the history and calculate the total price again.
            samsung.DeleteCall(samsung.ListOfCalls.OrderByDescending(c => c.CallDuration).First());
            Console.WriteLine(string.Join(Environment.NewLine, samsung.ListOfCalls));

            decimal priceWhenLongestCallIsRemoved = samsung.TotalPriceOfCalls();
            Console.WriteLine(priceWhenLongestCallIsRemoved);

            // Finally clear the call history and print it.
            samsung.ClearCallHistory();
            Console.WriteLine("History has been cleared!!!");
        }
    }
}