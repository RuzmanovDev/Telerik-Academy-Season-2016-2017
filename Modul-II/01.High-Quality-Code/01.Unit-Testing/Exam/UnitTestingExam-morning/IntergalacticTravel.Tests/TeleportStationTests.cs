using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.Mocks;

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
    public class TeleportStationTests
    {
        [Test]
        public void Constructor_WhenTeleportStationIsCreatedWithValidParameters_ShouldSetupAllProvidedFields()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            var mockedMap = new List<IPath>() { mockedPath.Object };

            // Act
            var teleportedStation = new MockedTeleportedStation(mockedOwner.Object, mockedMap, mockedLocation.Object);

            // Assert
            Assert.AreSame(mockedOwner.Object, teleportedStation.GetBusinnesOwner);
            Assert.AreSame(mockedMap, teleportedStation.GetGalacticMap);
            Assert.AreSame(mockedLocation.Object, teleportedStation.GetLocation);

        }

        [Test]
        public void TeleportUnit_WhenUnitToTeleportIsNull_ShouldThrowArgumentNullExceptionWithAMsgContainingUnitToTeleport()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            var mockedMap = new List<IPath>() { mockedPath.Object };

            var teleportedStation = new TeleportStation(mockedOwner.Object, mockedMap, mockedLocation.Object);
            var mockedTargetLocation = new Mock<ILocation>();
            // Act and Assert
            Assert.That(() => teleportedStation.TeleportUnit(null, mockedTargetLocation.Object),
                Throws.ArgumentNullException.With.Message.Contain("unitToTeleport"));
        }

        [Test]
        public void TeleportUnit_WhenLocationDestinationIsNull_ShouldThrowArgumenNullExceptionWithMessageContainingDestination()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            var mockedMap = new List<IPath>() { mockedPath.Object };

            var teleportedStation = new TeleportStation(mockedOwner.Object, mockedMap, mockedLocation.Object);
            var mockedUnitToTeleport = new Mock<IUnit>();

            // Act and Assert
            Assert.That(() => teleportedStation.TeleportUnit(mockedUnitToTeleport.Object, null),
                Throws.ArgumentNullException.With.Message.Contain("destination"));
        }

        [Test]
        public void TeleportUnit_WhenAUnitIsTryingToUseTheTeleporttStationFromAnotherPlanet_ShouldThrowTeleportOutOfRangeExceptionWithMsgunitToTeleportCurrentLocation()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            mockedLocation.Setup(x => x.Planet.Galaxy.Name).Returns("EarthGalaxy");
            mockedLocation.Setup(x => x.Planet.Name).Returns("Earth");

            var mockedMap = new List<IPath>() { mockedPath.Object };

            var teleportedStation = new TeleportStation(mockedOwner.Object, mockedMap, mockedLocation.Object);
            var mockedUnitToTeleport = new Mock<IUnit>();

            var mockedTargetLocation = new Mock<ILocation>();
            mockedTargetLocation.Setup(x => x.Planet.Galaxy.Name).Returns("FaaarAwayFormEarthGalaxy");
            mockedTargetLocation.Setup(x => x.Planet.Name).Returns("FaaarAwayFormEarth");

            mockedUnitToTeleport.Setup(x => x.CurrentLocation).Returns(mockedTargetLocation.Object);

            // Act and Assert
            var ex =
                Assert.Throws<TeleportOutOfRangeException>(
                    () => teleportedStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object));

            StringAssert.Contains("unitToTeleport.CurrentLocation", ex.Message);
        }

        [Test]
        public void TeleportUnit_WhenTryingToTeleportUnitToALocationWhichIsTaken_ShouldThrowInvalidTeleportationLocationExceptionWithMsgContainintunitsWill1Overlap()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            mockedLocation.Setup(x => x.Planet.Galaxy.Name).Returns("EarthGalaxy");
            mockedLocation.Setup(x => x.Planet.Name).Returns("Earth");
            mockedPath.Setup(x => x.TargetLocation).Returns(mockedLocation.Object);

            var mockedMap = new List<IPath>() { mockedPath.Object };

            var teleportedStation = new TeleportStation(mockedOwner.Object, mockedMap, mockedLocation.Object);
            var mockedUnitToTeleport = new Mock<IUnit>();

            var mockedOverlappingUnit = new Mock<IUnit>();

            var mockedTargetLocation = new Mock<ILocation>();
            mockedOverlappingUnit.Setup(x => x.CurrentLocation).Returns(mockedTargetLocation.Object);

            mockedTargetLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("EarthGalaxy");
            mockedTargetLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedTargetLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { mockedOverlappingUnit.Object });
            mockedLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { mockedUnitToTeleport.Object });

            mockedUnitToTeleport.Setup(x => x.CurrentLocation).Returns(mockedLocation.Object);

            var mockedGPsCoords = new Mock<IGPSCoordinates>();
            mockedLocation.Setup(x => x.Coordinates).Returns(mockedGPsCoords.Object);
            mockedTargetLocation.Setup(x => x.Coordinates).Returns(mockedGPsCoords.Object);
            // Act and Assert
            var ex =
                Assert.Throws<InvalidTeleportationLocationException>(
                    () => teleportedStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object));

            StringAssert.Contains("units will overlap", ex.Message);
        }

        [Test]
        public void TeleportUnit_WhenTryingToTeleportUnitToGalaxyWhichIsNoutFount_ShouldThrowLocationNotFoundExceptionWithAMsgContainingGalaxy()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            mockedLocation.Setup(x => x.Planet.Galaxy.Name).Returns("EarthGalaxy");
            mockedPath.Setup(x => x.TargetLocation).Returns(mockedLocation.Object);

            var mockedMap = new List<IPath>() { mockedPath.Object };

            var teleportedStation = new TeleportStation(mockedOwner.Object, mockedMap, mockedLocation.Object);
            var mockedUnitToTeleport = new Mock<IUnit>();

            var mockedOverlappingUnit = new Mock<IUnit>();

            var mockedTargetLocation = new Mock<ILocation>();
            mockedOverlappingUnit.Setup(x => x.CurrentLocation).Returns(mockedTargetLocation.Object);

            mockedTargetLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("EarthGalaxy2");
            mockedTargetLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { mockedOverlappingUnit.Object });
            mockedLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { mockedUnitToTeleport.Object });

            mockedUnitToTeleport.Setup(x => x.CurrentLocation).Returns(mockedLocation.Object);

            // Act and Assert
            var ex =
                Assert.Throws<LocationNotFoundException>(
                    () => teleportedStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object));

            StringAssert.Contains("Galaxy", ex.Message);
        }

        [Test]
        public void TeleportUnit_whenTryingToTeleportUnitToAPlanetWhichIsNoFoundInTheLocationList_ShouldThrowLocationNotFoundExceptionWithMsgContainingPlanet()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            mockedLocation.Setup(x => x.Planet.Galaxy.Name).Returns("EarthGalaxy");
            mockedLocation.Setup(x => x.Planet.Name).Returns("Earth");
            mockedPath.Setup(x => x.TargetLocation).Returns(mockedLocation.Object);

            var mockedMap = new List<IPath>() { mockedPath.Object };

            var teleportedStation = new TeleportStation(mockedOwner.Object, mockedMap, mockedLocation.Object);
            var mockedUnitToTeleport = new Mock<IUnit>();

            var mockedOverlappingUnit = new Mock<IUnit>();

            var mockedTargetLocation = new Mock<ILocation>();
            mockedOverlappingUnit.Setup(x => x.CurrentLocation).Returns(mockedTargetLocation.Object);

            mockedTargetLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("EarthGalaxy");
            mockedTargetLocation.SetupGet(x => x.Planet.Name).Returns("Earth2");
            mockedTargetLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { mockedOverlappingUnit.Object });
            mockedLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { mockedUnitToTeleport.Object });

            mockedUnitToTeleport.Setup(x => x.CurrentLocation).Returns(mockedLocation.Object);

            var mockedGPsCoords = new Mock<IGPSCoordinates>();
            mockedLocation.Setup(x => x.Coordinates).Returns(mockedGPsCoords.Object);
            mockedTargetLocation.Setup(x => x.Coordinates).Returns(mockedGPsCoords.Object);

            // Act and Assert
            var ex =
                Assert.Throws<LocationNotFoundException>(
                    () => teleportedStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object));

            StringAssert.Contains("Planet", ex.Message);
        }

        [Test]
        public void TeleportUnit_WhenTryingToTeleportUnitToGivenLocationButTheUnitDoesNotHaveenoughResources_ShouldThrowInsufficientResourcesExceptionWithMsgFreeLunch()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            mockedLocation.Setup(x => x.Planet.Galaxy.Name).Returns("EarthGalaxy");
            mockedLocation.Setup(x => x.Planet.Name).Returns("Earth");
            mockedPath.Setup(x => x.TargetLocation).Returns(mockedLocation.Object);

            var mockedMap = new List<IPath>() { mockedPath.Object };

            var teleportedStation = new TeleportStation(mockedOwner.Object, mockedMap, mockedLocation.Object);
            var mockedUnitToTeleport = new Mock<IUnit>();

            var mockedTargetLocation = new Mock<ILocation>();
            var anotherLocation = new Mock<ILocation>();

            mockedTargetLocation.SetupGet(x => x.Planet.Galaxy.Name).Returns("EarthGalaxy");
            mockedTargetLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { mockedUnitToTeleport.Object });

            mockedUnitToTeleport.Setup(x => x.CurrentLocation).Returns(anotherLocation.Object);

            var mockedGPsCoords = new Mock<IGPSCoordinates>();

            mockedLocation.Setup(x => x.Coordinates).Returns(mockedGPsCoords.Object);
            mockedTargetLocation.Setup(x => x.Coordinates).Returns(mockedGPsCoords.Object);


            // Act And Assert
            var ex = Assert.Throws<InsufficientResourcesException>(
                () => teleportedStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object));

            StringAssert.Contains("FREE LUNCH", ex.Message);

        }

        [Test]
        public void PayProfits_WhenTheArgumentpassedIsTheActualOwner_ShouldReturnTheTotalammountOfProfitsGeneratedByTheTransportUnitServise()
        {
            // Arrange
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedPath = new Mock<IPath>();
            var mockedLocation = new Mock<ILocation>();
            var mockedMap = new List<IPath>() { mockedPath.Object };

            var teleportedStation = new MockedTeleportedStation(mockedOwner.Object, mockedMap, mockedLocation.Object);
            var resources = new Resources(10, 10, 10);
            mockedOwner.Setup(x => x.TeleportStations.Add(teleportedStation));

            teleportedStation.AddResources(resources);

            // Act
            var result = teleportedStation.PayProfits(mockedOwner.Object);

            // Assert
            Assert.AreEqual(resources.BronzeCoins, result.BronzeCoins);
            Assert.AreEqual(resources.SilverCoins, result.SilverCoins);
            Assert.AreEqual(resources.GoldCoins, result.GoldCoins);
        }

    }
}
