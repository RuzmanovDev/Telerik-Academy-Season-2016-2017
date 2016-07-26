using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Poker.Tests
{
    [TestFixture]
    public class TestHand
    {
        [Test]
        public void ToString_WhenCalledWithTwoCards_ShouldPrintAllCards()
        {
            IList<ICard> cards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);

            var expected = "Ace of Clubs, Ace of Diamonds";
            var result = hand.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}
