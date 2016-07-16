using System;
using System.Globalization;
using System.Threading;
class garden
{
    static void Main()
    {
        // use "." 
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        //input
        int tomato = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
        int cucumber = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());
        int potato = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
        int carrot = int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
        int cabbage = int.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());
        int beans = int.Parse(Console.ReadLine());


        //Prices
        double tomatoPrice = 0.5;
        double cucumberPrice = 0.4;
        double potatoPrice = 0.25;
        double carrotPrice = 0.6;
        double cabbagePrice = 0.3;
        double beannsPrice = 0.4;
        int totalArea = 250;

        double totalCost = tomato * tomatoPrice + cucumber * cucumberPrice + potato * potatoPrice + carrot * carrotPrice + cabbage * cabbagePrice + beans * beannsPrice;
        int reminingArea = totalArea - (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea);
        //output
        Console.WriteLine("Total costs: {0:0.00}", totalCost);
        if (reminingArea > 0)
        {
            Console.WriteLine("Beans area: {0}", reminingArea);
        }
        else if (reminingArea == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Insufficient area");
        }
    }
}


