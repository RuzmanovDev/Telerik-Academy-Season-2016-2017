namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        // Task 1. In the Card class implement the ToString() method
        public override string ToString()
        {
            return $"{this.Face} of {this.Suit}";
        }

        public override bool Equals(object obj)
        {
            var secondCard = obj as Card;
            if (secondCard == null)
            {
                return false;
            }

            if (this.Face == secondCard.Face && this.Suit == secondCard.Suit)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Face.GetHashCode() ^ this.Suit.GetHashCode();
        }
    }
}
