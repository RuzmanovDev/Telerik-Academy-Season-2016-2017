using IntergalacticTravel.Exceptions;

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
    public class UnitsFactoryTests
    {
        [Test]
        public void GetUnit_WhenAValidCorrespondingCommandForCreatingProcyonIsPassed_ShouldReturnProcyon()
        {
            // Arrange

            var command = "create unit Procyon Gosho 1";
            var factory = new UnitsFactory();

            // Act
            var unit = factory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Procyon>(unit);
        }

        [Test]
        public void GetUnit_WhenAValidCorrespondingCommandForCreatingLuytenIsPassed_ShouldReturnLuyten()
        {
            // Arrange
            var command = "create unit Luyten Pesho 2";
            var factory = new UnitsFactory();

            // Act
            var unit = factory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Luyten>(unit);
        }

        [Test]
        public void GetUnit_WhenAValidCorrespondingCommandForCreatingLacailleIsPassed_ShouldReturnLacaille()
        {
            // Arrange
            var command = "create unit Lacaille Tosho 3";
            var factory = new UnitsFactory();

            // Act
            var unit = factory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Lacaille>(unit);
        }

        [TestCase("unit create Procyon Gosho 100000000000")]
        [TestCase("create unit Proyon Gosho 1")]
        [TestCase("createunit Procyon Gosho 1")]
        public void GetUnit_WhenInvalidCommandIsPassed_ShouldThrowInvalidUnitCreationCommandException(string invalidCommand)
        {
            // Arange
            var factory = new UnitsFactory();

            // Act and Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(invalidCommand));
        }

    }
}
