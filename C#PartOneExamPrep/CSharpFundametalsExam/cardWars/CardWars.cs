using System;
using System.Numerics;

class CardWars
{
    static void Main()
    {


        int games = int.Parse(Console.ReadLine());

        BigInteger player1Score = 0;
        BigInteger player2Score = 0;
        bool player1HasXcard = false;
        bool player2HasXcard = false;
        int player1Games = 0;
        int player2Games = 0;
        int yCounter = 0;
        int zCounter = 0;

        for (int i = 0; i < games; i++)
        {
            BigInteger player1TempScore = 0;
            BigInteger player2TempScore = 0;


            //read 1 player

            for (int j = 0; j < 3; j++)
            {
                string hand = Console.ReadLine();

                switch (hand)
                {
                    case "A": player1TempScore += 1; break;
                    case "J": player1TempScore += 11; break;
                    case "Q": player1TempScore += 12; break;
                    case "K": player1TempScore += 13; break;
                    case "X": player1HasXcard = true; ; break;
                    case "Y": player1TempScore -= 200; break;
                    case "Z": player1TempScore *= 2; break;
                    default: player1TempScore += 12 - int.Parse(hand); break;
                }
                if (hand == "Y" && yCounter == 0)
                {
                    player1TempScore -= 200;
                }
                else if (hand == "Y" && yCounter == 1)
                {
                    player1TempScore -= 400;
                }
                else if (hand == "Y" && yCounter == 2)
                {
                    player1TempScore -= 600;
                }
                //Z
                if (hand == "Z" && zCounter == 0)
                {
                    player1TempScore *= 2;
                }
                else if (hand == "Z" && zCounter == 1)
                {
                    player1TempScore *= 4;
                }
                else if (hand == "Z" && zCounter == 2)
                {
                    player1TempScore *= 8;
                }
            }
            zCounter = 0;
            yCounter = 0;
            for (int j = 0; j < 3; j++)
            {
                string hand = Console.ReadLine();

                switch (hand)
                {
                    case "A": player2TempScore += 1; break;
                    case "J": player2TempScore += 11; break;
                    case "Q": player2TempScore += 12; break;
                    case "K": player2TempScore += 13; break;
                    case "X": player2HasXcard = true; ; break;
                    //case "Y": player2TempScore -= 200; ++yCounter; break;
                    //case "Z": player2TempScore *= 2; ++zCounter; break;
                    default: player2TempScore += 12 - int.Parse(hand); break;
                }
                //y
                if (hand == "Y" && yCounter == 0)
                {
                    player2TempScore -= 200;
                }
                else if (hand == "Y" && yCounter == 1)
                {
                    player2TempScore -= 400;
                }
                else if (hand == "Y" && yCounter == 2)
                {
                    player2TempScore -= 600;
                }
                //Z
                if (hand == "Z" && zCounter == 0)
                {
                    player2TempScore *= 2;
                }
                else if (hand == "Z" && zCounter == 1)
                {
                    player2TempScore *= 4;
                }
                else if (hand == "Z" && zCounter == 2)
                {
                    player2TempScore *= 8;
                }


            }
            if (player1HasXcard)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                return;
            }
            else if (player2HasXcard)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                return;
            }
            else if (player1HasXcard && player2HasXcard)
            {
                player1Score += 50;
                player2Score += 50;
            }
            if (player1TempScore > player2TempScore)
            {
                player1Score += player1TempScore;
                ++player1Games;
            }
            else if (player1TempScore < player2TempScore)
            {
                player2Score += player2TempScore;
                ++player2Games;
            }



        }


        if (player1Games > player2Games)
        {
            Console.WriteLine(@"First player wins!
Score: {0}
Games won: {1}", player1Score, player1Games
);
        }
        else if (player1Games < player2Games)
        {
            Console.WriteLine(@"Second player wins!
Score: {0}
Games won: {1}", player2Score, player2Games);
        }
        else
        {
            Console.WriteLine(@"It's a tie!
Score: {0}", player1Score);
        }


    }
}

