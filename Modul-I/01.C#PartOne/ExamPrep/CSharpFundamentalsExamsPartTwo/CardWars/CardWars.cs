namespace CardWars
{
    using System;
    using System.Numerics;

    public class CardWars
    {
        public static void Main(string[] args)
        {
            int round = int.Parse(Console.ReadLine());
            BigInteger playerOneTotal = 0;
            int playerOneGames = 0;

            BigInteger playerTwoTotal = 0;
            int playerTwoGames = 0;

            for (int i = 0; i < round; i++)
            {
                BigInteger firstPlayerCurrentScore = 0;
                BigInteger secondPlayerCurrentScore = 0;
                bool fpHasX = false;
                bool spHasX = false;

                //firstPlayerCards
                for (int j = 0; j < 3; j++)
                {
                    string currentCard = Console.ReadLine();
                    switch (currentCard)
                    {
                        case "A":
                            firstPlayerCurrentScore += 1;
                            break;
                        case "J":
                            firstPlayerCurrentScore += 11;
                            break;
                        case "Q":
                            firstPlayerCurrentScore += 12;
                            break;
                        case "K":
                            firstPlayerCurrentScore += 13;
                            break;
                        case "Z":
                            playerOneTotal *= 2;
                            break;
                        case "Y":
                            playerOneTotal -= 200;
                            break;
                        case "X":
                            fpHasX = true;
                            break;
                        default:
                            firstPlayerCurrentScore += 12 - BigInteger.Parse(currentCard);
                            break;
                    }
                }

                // second player
                for (int j = 0; j < 3; j++)
                {
                    string currentCard = Console.ReadLine();
                    switch (currentCard)
                    {
                        case "A":
                            secondPlayerCurrentScore += 1;
                            break;
                        case "J":
                            secondPlayerCurrentScore += 11;
                            break;
                        case "Q":
                            secondPlayerCurrentScore += 12;
                            break;
                        case "K":
                            secondPlayerCurrentScore += 13;
                            break;
                        case "Z":
                            playerTwoTotal *= 2;
                            break;
                        case "Y":
                            playerTwoTotal -= 200;
                            break;
                        case "X":
                            spHasX = true;
                            break;
                        default:
                            secondPlayerCurrentScore += 12 - BigInteger.Parse(currentCard);
                            break;
                    }
                }

                if (fpHasX && !spHasX)
                {
                    Console.WriteLine("X card drawn! Player one wins the match!");
                    return;
                }
                else if (!fpHasX && spHasX)
                {
                    Console.WriteLine("X card drawn! Player two wins the match!");
                    return;
                }
                else if (fpHasX && spHasX)
                {
                    playerOneTotal += 50;
                    playerTwoTotal += 50;
                }

                if (firstPlayerCurrentScore > secondPlayerCurrentScore)
                {
                    playerOneTotal += firstPlayerCurrentScore;
                    playerOneGames++;
                }
                else if (firstPlayerCurrentScore < secondPlayerCurrentScore)
                {
                    playerTwoTotal += secondPlayerCurrentScore;
                    playerTwoGames++;
                }
            }

            if (playerOneTotal > playerTwoTotal)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", playerOneTotal);
                Console.WriteLine("Games won: {0}", playerOneGames);
            }
            else if (playerOneTotal < playerTwoTotal)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", playerTwoTotal);
                Console.WriteLine("Games won: {0}", playerTwoGames);
            }
            else if (playerOneTotal == playerTwoTotal)
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", playerOneTotal);
            }


        }
    }
}
