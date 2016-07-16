namespace KovrataAni
{
    using System;

    class AniTheWh
    {
        static void Main(string[] args)
        {
            long numberOfCabins = long.Parse(Console.ReadLine()); // n

            string input = "";
            long currentPos = 0;
            long totalSteps = 0;
            long nextToiletPos = 0;
            while (input != "Found a free one!")
            {
                long number = 0;
                input = Console.ReadLine();
                bool isNumber = long.TryParse(input, out number);
                if (!isNumber)
                {
                    break;
                }
                long stepsTaken = 0;
                // find the next toilet
                //for (int i = 0; i < number; i++)
                //{
                //    nextToiletPos++;
                //    if (nextToiletPos > numberOfCabins - 1)
                //    {
                //        nextToiletPos = 0;
                //    }
                //}
                nextToiletPos = (currentPos + number) % numberOfCabins;

                //find the shrotest path
                if (nextToiletPos > currentPos)
                {
                    stepsTaken = nextToiletPos - currentPos;
                    Console.WriteLine("Go {0} steps to the right, Ani.", stepsTaken);
                    totalSteps += stepsTaken;

                }
                else if (nextToiletPos < currentPos)
                {
                    stepsTaken = currentPos - nextToiletPos;
                    Console.WriteLine("Go {0} steps to the left, Ani.", stepsTaken);
                    totalSteps += stepsTaken;
                }
                else
                {
                    Console.WriteLine("Stay there, Ani.");
                    totalSteps += stepsTaken;
                }

                currentPos = nextToiletPos;
               // input = Console.ReadLine();

            }
            Console.WriteLine("Moved a total of {0} steps.", totalSteps);
        }
    }
}
