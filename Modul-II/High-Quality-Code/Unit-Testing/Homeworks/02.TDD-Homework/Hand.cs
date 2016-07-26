namespace Poker
{
    using System.Collections.Generic;

    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        // Task 2. In the Hand class implement the ToString() method
        public override string ToString()
        {
            return string.Join(", ", this.Cards);
        }
    }
}
