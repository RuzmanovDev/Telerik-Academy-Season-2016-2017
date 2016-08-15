using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class ResourcesFactoryTests
    {

        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResources_WhenPassedValidArgumentsInspiteOfTheiOrder_ShouldReturnNewlyCreatedResources(
              string command)
        {
            // Arrange
            var resourceFactory = new ResourcesFactory();

            // Act
            var resource = resourceFactory.GetResources(command);

            // Assert
            Assert.AreEqual(20, resource.GoldCoins);
            Assert.AreEqual(30, resource.SilverCoins);
            Assert.AreEqual(40, resource.BronzeCoins);
        }

        [TestCase("RandomStringThatShouldThrowException")]
        [TestCase("RandomStringThatShouldThrowException")]
        [TestCase("craft resource bronze[40] silver[30] gold[20]")]
        public void GetResources_WhenInvalidCommandIsPassed_ShouldThrowInvalidOperationException(string invalidComamnd)
        {
            // Arrange
            var resourceFactory = new ResourcesFactory();

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => resourceFactory.GetResources(invalidComamnd));
        }

        [TestCase("create resources gold(200000000000) silver(30) bronze(40)")]
        [TestCase("create resources silver(30) bronze(40000000000000) gold(20)")]
        [TestCase("create resources silver(3000000000000) gold(20) bronze(40)")]
        public void
            GetResources_WhenInputStringIsInCorrectFormatButAnyOfTheValuesOverflowsTheUintMaxValue_ShouldThrowOverflowException
            (string command)
        {
            // Arrange
            var factory = new ResourcesFactory();

            // Act and Assert
            Assert.Throws<OverflowException>(() => factory.GetResources(command));
        }
    }
}
