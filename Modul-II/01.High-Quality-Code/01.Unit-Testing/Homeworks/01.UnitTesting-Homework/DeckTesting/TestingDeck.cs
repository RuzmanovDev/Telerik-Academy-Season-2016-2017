namespace DeckTesting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using NUnit.Framework;
    using Santase.Logic;
    using Santase.Logic.Cards;

    [TestFixture]
    public class TestingDeck
    {
        [Test]
        public void GetNextCard_WhenryingToGetCardFromListWithCount0_ExceptionShouldBeTrown()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [Test]
        public void TrumpCard_ShouldBeNonNullable()
        {
            IDeck deck = new Deck();
            Assert.IsNotNull(deck.TrumpCard);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(15)]
        [TestCase(23)]
        [TestCase(24)]
        public void GetNextCard_WhenCardIsDrawn_TheNumberOfCardsInTheDeckMustDecreaseByTheNumberOfDrawnCards(int drawedCards)
        {
            var deck = new Deck();

            for (int i = 0; i < drawedCards; i++)
            {
                var card = deck.GetNextCard();
            }

            Assert.AreEqual(24 - drawedCards, deck.CardsLeft);
        }

        [Test]
        public void CardsLeft_WhenNewDeckIsCreated_ShouldBe24()
        {
            IDeck deck = new Deck();
            int cards = deck.CardsLeft;
            Assert.AreEqual(24, cards);
        }

        [Test]
        public void ChangetTrumpCard_WhenCalled_ShouldGetTheLastCard()
        {
            IDeck deck = new Deck();
            Card changed = new Card(CardSuit.Club, CardType.King);
            deck.ChangeTrumpCard(changed);
            for (int i = 0; i < 23; i++)
            {
                deck.GetNextCard();
            }

            Card card = deck.GetNextCard();

            Assert.AreEqual(card, changed);
        }

        [Test]
        public void GetNext_WhenCalled_ShouldNotChangeTrumpCard()
        {
            IDeck deck = new Deck();

            var card = deck.TrumpCard;
            deck.GetNextCard();

            Assert.AreEqual(card, deck.TrumpCard);
        }
    }
}
