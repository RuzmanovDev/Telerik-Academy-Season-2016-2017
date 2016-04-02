using System;
using System.Numerics;
class cardWarsBatka
{
    static void Main()
    {

        //input
        int numberOfGames = int.Parse(Console.ReadLine());
        //vars
        BigInteger firstPlayerScore = 0;
        BigInteger secondPlayerScore = 0;

        int playerOneGameCounter = 0;
        int secondPlayerGameCounter = 0;



        for (int i = 0; i < numberOfGames; i++)
        {
            BigInteger playerOneTempScore = 0;
            BigInteger secondPlayerTempScore = 0;
            bool xCounterFirst = false;
            bool xCounterSecond = false;

            for (int j = 0; j < 3; j++)
            {
                string cardDraw = Console.ReadLine();

                switch (cardDraw)
                {
                    case "2": playerOneTempScore += 10; break;
                    case "3": playerOneTempScore += 9; break;
                    case "4": playerOneTempScore += 8; break;
                    case "5": playerOneTempScore += 7; break;
                    case "6": playerOneTempScore += 6; break;
                    case "7": playerOneTempScore += 5; break;
                    case "8": playerOneTempScore += 4; break;
                    case "9": playerOneTempScore += 3; break;
                    case "10": playerOneTempScore += 2; break;
                    case "A": playerOneTempScore += 1; break;
                    case "J": playerOneTempScore += 11; break;
                    case "Q": playerOneTempScore += 12; break;
                    case "K": playerOneTempScore += 13; break;
                    case "Z": playerOneTempScore *= 2; break;
                    case "Y": playerOneTempScore -= 200; break;
                    case "X": xCounterFirst = true; break;

                    default: break;
                }

            }

            //secondPlayer

            for (int j = 0; j < 3; j++)
            {
                string cardDraw = Console.ReadLine();

                switch (cardDraw)
                {
                    case "2": secondPlayerTempScore += 10; break;
                    case "3": secondPlayerTempScore += 9; break;
                    case "4": secondPlayerTempScore += 8; break;
                    case "5": secondPlayerTempScore += 7; break;
                    case "6": secondPlayerTempScore += 6; break;
                    case "7": secondPlayerTempScore += 5; break;
                    case "8": secondPlayerTempScore += 4; break;
                    case "9": secondPlayerTempScore += 3; break;
                    case "10": secondPlayerTempScore += 2; break;
                    case "A": secondPlayerTempScore += 1; break;
                    case "J": secondPlayerTempScore += 11; break;
                    case "Q": secondPlayerTempScore += 12; break;
                    case "K": secondPlayerTempScore += 13; break;
                    case "Z": secondPlayerTempScore *= 2; break;
                    case "Y": secondPlayerTempScore -= 200; break;
                    case "X": xCounterSecond = true; break;

                    default: break;
                }

            }
            if (xCounterFirst==true && xCounterSecond==false)
            {
                Console.Write("X card drawn! Player one wins the match!");

                return;
            }
            else if (xCounterSecond==true && xCounterFirst==false)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");

                return;
            }
            else if (xCounterFirst==true && xCounterSecond==true)
            {
                playerOneTempScore += 50;
                secondPlayerTempScore += 50;
            }

            if (playerOneTempScore > secondPlayerTempScore && xCounterFirst!=xCounterSecond)
            {
                firstPlayerScore += playerOneTempScore;
                playerOneTempScore = 0;
                ++playerOneGameCounter;

            }
            else if (playerOneTempScore < secondPlayerTempScore && xCounterFirst != xCounterSecond )
            {
                secondPlayerScore += secondPlayerTempScore;
                secondPlayerTempScore = 0;
                ++secondPlayerGameCounter;
            }
            else if (playerOneTempScore == secondPlayerTempScore && xCounterFirst != xCounterSecond)
            {
                secondPlayerTempScore = 0;
                playerOneTempScore = 0;
            }

            //comparing scores and define winner


        }
        if (firstPlayerScore > secondPlayerScore)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", firstPlayerScore);
            Console.WriteLine("Games won: {0}", playerOneGameCounter);
        }
        else if (secondPlayerScore > firstPlayerScore)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", secondPlayerScore);
            Console.WriteLine("Games won: {0}", secondPlayerGameCounter);
        }
        else if (secondPlayerScore == firstPlayerScore)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", firstPlayerScore);
        }




    }
}

