using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Poker.Tests
{
    [TestFixture]
    public class TestCard
    {
        [Test]
        public void ToString_ShouldReturnAceOfDiamonds_WhenCalledOnAceOfDiamonds()
        {
            var card = new Card(CardFace.Ace, CardSuit.Diamonds);
            var expectedResult = "Ace of Diamonds";
            var actualResult = card.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }

       
    }
}
