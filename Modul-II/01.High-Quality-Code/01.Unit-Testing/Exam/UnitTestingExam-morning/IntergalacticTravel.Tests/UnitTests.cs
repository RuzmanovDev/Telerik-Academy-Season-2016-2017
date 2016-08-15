namespace IntergalacticTravel.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Moq;

    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pay_WhenNullObjectIsPassed_ShouldThrowNullReferenceException()
        {
            // Arange
            var unit = new Unit(1, "pesho");

            // Act and Assert
            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void Pay_WhenCalled_ShouldDecreaseOwnersAmountOfResources()
        {
            // Arrange
            var unit = new Unit(1, "pesho");
            var resources = new Resources(1, 1, 1);
            unit.Resources.Add(resources);

            // Act
            unit.Pay(resources);

            // Asssert
            Assert.AreEqual(0, unit.Resources.GoldCoins);
            Assert.AreEqual(0, unit.Resources.SilverCoins);
            Assert.AreEqual(0, unit.Resources.BronzeCoins);
        }

        [Test]
        public void Pay_WhenCalled_ShouldReturnResourceObjectWithTheAmountOfResourcesInTheCostObject()
        {
            // Arrange
            var unit = new Unit(1, "pesho");
            var resources = new Resources(10, 10, 10);
            unit.Resources.Add(resources);
            var cost = new Resources(5, 5, 5);

            // Act
            var result = unit.Pay(cost);

            // Assert
            Assert.AreEqual(cost.GoldCoins, result.GoldCoins);
            Assert.AreEqual(cost.SilverCoins, result.SilverCoins);
            Assert.AreEqual(cost.BronzeCoins, result.BronzeCoins);
        }
    }
}
