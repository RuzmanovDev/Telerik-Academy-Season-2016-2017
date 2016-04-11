namespace Poker
{
    using System;

    public class Poker
    {
        public static void Main(string[] args)
        {
            int[] cards = new int[5];

            for (int i = 0; i < cards.Length; i++)
            {
                string input = Console.ReadLine();
                if (input == "A")
                {
                    cards[i] = 1;
                }
                else if (input == "J")
                {
                    cards[i] = 11;
                }
                else if (input == "Q")
                {
                    cards[i] = 12;
                }
                else if (input == "K")
                {
                    cards[i] = 13;
                }
                else
                {
                    cards[i] = int.Parse(input);
                }
            }

            bool isImmposible = false;
            bool isFourOfAKind = false;
            bool isFullHouse = false;
            bool isStraight = false;
            bool isThreeOfAKind = false;
            bool isTwoPairs = false;
            bool isOnePair = false;
            bool isNothing = true;

            Array.Sort(cards);

            if (cards[0] == cards[1] && cards[0] == cards[2] && cards[0] == cards[3] && cards[0] == cards[4])
            {
                // immposibble

                isImmposible = true;
                if (isImmposible)
                {
                    Console.WriteLine("Impossible");
                    return;
                }
            }
            else if ((cards[0] + 1 == cards[1] && cards[0] + 2 == cards[2] && cards[0] + 3 == cards[3] && cards[0] + 4 == cards[4])
                       || (cards[0] == 1 && cards[1] == 10 && cards[2] == 11 && cards[3] == 12 && cards[4] == 13))
            {
                isStraight = true;
                if (isStraight)
                {
                    Console.WriteLine("Straight");
                    return;
                }
            }

            // logic
            int fourOfAKind = 1;
            int secondPair = 0;
            int numberOfPairs = 0;

            for (int i = 0; i < cards.Length - 1; i++)
            {
                int currentCard = cards[i];
                for (int j = i + 1; j < cards.Length; j++)
                {
                    if (currentCard == cards[j])
                    {
                        fourOfAKind++;
                        numberOfPairs++;
                        if (isOnePair)
                        {
                            secondPair++;
                        }
                    }
                }

                if (fourOfAKind == 4)
                {
                    isFourOfAKind = true;
                    if (isFourOfAKind)
                    {
                        Console.WriteLine("Four of a Kind");
                        return;
                    }
                }
                else
                {
                    fourOfAKind = 1;
                }

                if (numberOfPairs == 1)
                {
                    isOnePair = true;
                    numberOfPairs = 0;
                }
                else if (numberOfPairs == 2)
                {
                    isThreeOfAKind = true;
                    numberOfPairs = 0;
                    i++; // skips the next element so i will not count the trhee of a kind as two pairs
                }
                else
                {
                    numberOfPairs = 0;
                }

                if (secondPair == 1)
                {
                    isTwoPairs = true;
                }
                else
                {
                    isTwoPairs = false;
                }
            }

            if (isOnePair && isThreeOfAKind)
            {
                isFullHouse = true;
            }

            if (isFullHouse)
            {
                Console.WriteLine("Full House");
            }
            else if (isThreeOfAKind)
            {
                Console.WriteLine("Three of a Kind");
            }
            else if (isTwoPairs)
            {
                Console.WriteLine("Two Pairs");
            }
            else if (isOnePair)
            {
                Console.WriteLine("One Pair");
            }
            else if (isNothing)
            {
                Console.WriteLine("Nothing");
            }
        }
    }
}
