using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.Mocks;
using NUnit.Framework;
using Moq;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class BusinessOwnerTests
    {
        [Test]
        public void CollectProffits_WhenCalled_ShouldIncreaseTheOwnerResourcesByTheAmmountGeneratedFromTheTeleportStattionsInPossetion()
        {
            // Arrange
            var mockedIPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            var mockedMap = new List<IPath>() { mockedIPath.Object };
            var mockedStation = new Mock<ITeleportStation>();
            var owner = new BusinessOwner(1, "Pesho", new List<ITeleportStation>() { mockedStation.Object });
            var resources = new Resources(10, 10, 10);

            mockedStation.Setup(x => x.PayProfits(owner)).Returns(resources);

            // Act
            owner.CollectProfits();

            // Assert
            Assert.AreEqual(10, owner.Resources.GoldCoins);
            Assert.AreEqual(10, owner.Resources.SilverCoins);
            Assert.AreEqual(10, owner.Resources.BronzeCoins);
        }
    }
}
