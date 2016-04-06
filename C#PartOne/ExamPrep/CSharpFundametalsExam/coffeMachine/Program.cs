using System;
using System.Globalization;
using System.Threading;
class coffeMachine
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double trayOne = 0.05;
        double trayTwo = 0.10;
        double trayThree = 0.20;
        double trayFour = 0.50;
        double trayFive = 1.00;

        double n1 = double.Parse(Console.ReadLine()) * trayOne;
        double n2 = double.Parse(Console.ReadLine()) * trayTwo;
        double n3 = double.Parse(Console.ReadLine()) * trayThree;
        double n4 = double.Parse(Console.ReadLine()) * trayFour;
        double n5 = double.Parse(Console.ReadLine()) * trayFive;
        double total = n1 + n2 + n3 + n4 + n5;


        double ammount = double.Parse(Console.ReadLine());
        double price = double.Parse(Console.ReadLine());

        if (ammount>price && total>ammount-price)
        {
            Console.WriteLine("Yes {0:0.00}", total - (ammount-price));
        }
        else if (ammount<price)
        {
            Console.WriteLine("More {0:0.00}", price-ammount);
        }
        else if (ammount>price && total< ammount-price)
        {
            Console.WriteLine("No {0:0.00}",  (ammount - price)-total);
        }





    }
}

