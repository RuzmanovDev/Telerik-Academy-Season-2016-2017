namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class TestPokerHandsChecker
    {
        #region IsValidHandTests
        [Test]
        public void IsValidHand_WhenHandConsistOfFiveDifferentCards_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs)
            };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var result = checker.IsValidHand(hand);

            Assert.True(result);
        }

        [Test]
        public void IsValidHand_WhenNullhandIsPassed_ShouldThrowArgumentNullException()
        {
            var checker = CreatePokerHandChecker();

            Assert.Throws<ArgumentNullException>(() => checker.IsValidHand(null));
        }

        [Test]
        public void IsValidHand_WhenHandConsistOfSixCards_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)

            };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var result = checker.IsValidHand(hand);

            Assert.False(result);
        }

        [Test]
        public void IsValidHand_WhenHandHasTwoSameCards_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs)
            };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var result = checker.IsValidHand(hand);

            Assert.False(result);
        }
        #endregion

        #region IsStraightFlushTests
        [Test]
        public void IsStraightFlush_WhenPlayerHasStraightFlush_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
        };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var result = checker.IsStraightFlush(hand);

            Assert.True(result);

        }


        [Test]
        public void IsStraightFlush_WhenPlayerHasStraight_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds)
        };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var result = checker.IsStraightFlush(hand);

            Assert.False(result);
        }

        [Test]
        public void IsStraightFlush_WhenPlayerHasFlush_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
        };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var result = checker.IsStraightFlush(hand);

            Assert.False(result);
        }
        #endregion

        #region IsFlushTests
        [Test]
        public void IsFlush_WhenHandContainsFiveClubs_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isFlush = checker.IsFlush(hand);

            Assert.True(isFlush);
        }

        [Test]
        public void IsFlush_WhenHandContainsFiveSpades_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isFlush = checker.IsFlush(hand);

            Assert.True(isFlush);
        }

        [Test]
        public void IsFlush_WhenHandContainsFiveHearts_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isFlush = checker.IsFlush(hand);

            Assert.True(isFlush);
        }

        [Test]
        public void IsFlush_WhenHandContainsFiveDiamonds_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isFlush = checker.IsFlush(hand);

            Assert.True(isFlush);
        }

        [Test]
        public void IsFlush_WhenHandContainsDifferentSuits_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isFlush = checker.IsFlush(hand);

            Assert.False(isFlush);
        }

        #endregion

        #region IsOnePairTests
        [Test]
        public void IsOnePair_WhenPlayerHasPariInHand_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();

            Assert.True(checker.IsOnePair(hand));

        }

        [Test]
        public void IsOnePair_WhenPlayerHasMoreThanOnePair_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();

            Assert.False(checker.IsOnePair(hand));

        }
        #endregion

        #region IsTwoPairsTests
        [Test]
        public void IsTwoPair_WhenPlayerHasTwoPairs_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();

            Assert.True(checker.IsTwoPair(hand));

        }

        [Test]
        public void IsTwoPair_WhenPlayerHasLessThanTwoPairs_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();

            Assert.False(checker.IsTwoPair(hand));

        }

        [Test]
        public void IsTwoPair_WhenPlayerHasMoreThanTwoPairs_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();

            Assert.False(checker.IsTwoPair(hand));

        }
        #endregion

        #region IsThreeOfAKindTests
        [Test]
        public void IsThreeOfAKind_WhenPlayerHandHasThreeOfAKind_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();

            Assert.True(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKind_WhenPlayerHandHasStraight_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();

            Assert.False(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKind_WhenPlayerHasFullHouse_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();

            Assert.False(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKind_WhenPlayerHasFourOfAKind_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();

            Assert.False(checker.IsThreeOfAKind(hand));
        }
        #endregion

        #region IsStraightTests
        [Test]
        public void IsStraight_WhenPlayerHasStraight_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds)
        };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var result = checker.IsStraight(hand);

            Assert.True(result);
        }

        [Test]
        public void IsStraight_WhenPlayerHasStraightFlush_ShouldReturnFalse()
        {

            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
        };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var result = checker.IsStraight(hand);

            Assert.False(result);
        }

        [Test]
        public void IsStraight_WhenPlayerHasFullHouse_ShouldReturnFalse()
        {

            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Spades)
        };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var result = checker.IsStraight(hand);

            Assert.False(result);
        }

        #endregion

        #region IsFourOfAKindTests
        [Test]
        public void IsFourOfAKind_WhenPlayerHandhasFourOfAKindCards_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isFourOfAKind = checker.IsFourOfAKind(hand);

            Assert.True(isFourOfAKind);
        }

        [Test]
        public  void IsFourOfAKind_WhenPlayerHasThreeOfAKIndCards_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isFourOfAKind = checker.IsFourOfAKind(hand);

            Assert.False(isFourOfAKind);
        }

        public void IsFourOfAKind_WhenPlayerHasFlush_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isFourOfAKind = checker.IsFourOfAKind(hand);

            Assert.False(isFourOfAKind);
        }

        #endregion

        #region IsFullHouseTests
        [Test]
        public void IsFullHouse_WhenPlayerHasFullHouse_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isFullHouse = checker.IsFullHouse(hand);

            Assert.True(isFullHouse);
        }

        [Test]
        public void IsFullHouse_WhenPlayerHasFourOfAKind_ShouldReturnFalse()
        {

            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isFullHouse = checker.IsFullHouse(hand);

            Assert.False(isFullHouse);
        }
        #endregion

        #region HighCardTests
        [Test]
        public void IsHighCard_WhenPlayerHasNoOtherCombinations_ShouldReturnTrue()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isHighCard = checker.IsHighCard(hand);

            Assert.True(isHighCard);
        }

        [Test]
        public void IsHightCard_WhenPlayerHasOnePai_ShouldReturnFalse()
        {
            var listOfCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs)
             };

            var hand = new Hand(listOfCards);
            var checker = CreatePokerHandChecker();
            var isHighCard = checker.IsHighCard(hand);

            Assert.False(isHighCard);
        }
        #endregion

        private IPokerHandsChecker CreatePokerHandChecker()
        {
            return new PokerHandsChecker();
        }
    }
}
