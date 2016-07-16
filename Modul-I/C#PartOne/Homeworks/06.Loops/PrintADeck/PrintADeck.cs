namespace PrintADeck
{
    using System;

    public class PrintADeck
    {
        public static void Main(string[] args)
        {
            string card = Console.ReadLine();
            string[] deck = new string[13];
            int value = 2;
            for (int i = 0; i < deck.Length - 4; i++)
            {
                deck[i] = value.ToString();
                value++;
            }

            deck[9] = "J";
            deck[10] = "Q";
            deck[11] = "K";
            deck[12] = "A";

            for (int i = 0; i <= Array.IndexOf(deck, card); i++)
            {
                Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", deck[i]);
            }
        }
    }
}
