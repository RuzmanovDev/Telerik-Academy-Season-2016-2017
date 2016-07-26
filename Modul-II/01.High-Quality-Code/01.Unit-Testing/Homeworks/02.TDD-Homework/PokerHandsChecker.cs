namespace Poker
{
    using System;
    using System.Linq;

    // Task 3. In the PokerHandsChecker class implement the IsValidHand(IHand) method
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int NumberOfCardsInValidHand = 5;

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("Hand can't be null!");
            }

            var cards = hand.Cards;

            bool isValid = cards.Distinct()
                .Count() == NumberOfCardsInValidHand;

            return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            var isStraight = true;

            var sorted = hand.Cards.Select(value => (int)value.Face).OrderBy(value => value).ToArray();

            if (sorted.Contains((int)CardFace.Ace) && sorted.Contains((int)CardFace.Two))
            {
                var index = Array.IndexOf(sorted, (int)CardFace.Ace);
                sorted[index] = 1;
                sorted = sorted.OrderBy(value => value).ToArray();
            }

            for (int ind = 0; ind < sorted.Length - 1; ind++)
            {
                if (sorted[ind] + 1 != sorted[ind + 1])
                {
                    isStraight = false;
                    break;
                }
            }

            bool isFlush = hand.Cards.GroupBy(card => card.Suit).Count() == 1;

            return isStraight && isFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var group = hand.Cards.GroupBy(card => card.Face);
            var isFourOfAKind = group.Any(gr => gr.Count() == 4);

            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var group = hand.Cards.GroupBy(card => card.Face);
            var isFullHouse = group.Any(gr => gr.Count() == 3)
                            && group.Any(gr=>gr.Count()==2);

            return isFullHouse;
        }

        // Task 4. In the PokerHandsChecker class implement the IsFlush(IHand) method
        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var cards = hand.Cards;

            bool areSameSuit = cards.GroupBy(c => c.Suit)
                                    .Count() == 1;

            return areSameSuit;
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (hand.Cards.GroupBy(card => card.Suit).Count() == 1)
            {
                return false;
            }

            var sorted = hand.Cards.Select(value => (int)value.Face).OrderBy(value => value).ToArray();

            if (sorted.Contains((int)CardFace.Ace) && sorted.Contains((int)CardFace.Two))
            {
                var index = Array.IndexOf(sorted, (int)CardFace.Ace);
                sorted[index] = 1;
                sorted = sorted.OrderBy(value => value).ToArray();
            }

            for (int ind = 0; ind < sorted.Length - 1; ind++)
            {
                if (sorted[ind] + 1 != sorted[ind + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var group = hand.Cards.GroupBy(card => card.Face);
            var isThreeOfAKind = group.Any(gr => gr.Count() == 3)
                                 && !group.Any(gr => gr.Count() == 2);

            return isThreeOfAKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            return hand.Cards.GroupBy(card => card.Face).Count(group => group.Count() == 2) == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var group = hand.Cards.GroupBy(card => card.Face);
            return group.Count(gr => gr.Count() == 2) == 1 && !group.Any(gr => gr.Count() == 3);
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var group = hand.Cards.GroupBy(card => card.Face);
            return !this.IsFlush(hand) && group.Count() == PokerHandsChecker.NumberOfCardsInValidHand;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            // not enough time :(
            throw new NotImplementedException();
        }
    }
}
