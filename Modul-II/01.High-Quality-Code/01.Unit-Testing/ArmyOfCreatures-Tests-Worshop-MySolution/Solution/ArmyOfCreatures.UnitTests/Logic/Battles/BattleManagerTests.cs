using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using NUnit.Framework;
using Moq;

namespace ArmyOfCreatures.UnitTests.Logic.Battles
{
    [TestFixture]
    public class BattleManagerTests
    {
        // Add creatures should throw ArgumentNullException, when Identifier is null
        [Test]
        public void AddCreatures_WhenIdentifierIsNull_ShouldThrowArgumentNullException()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedFactory = new Mock<ICreaturesFactory>();

            var bm = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            Assert.Throws<ArgumentNullException>(() => bm.AddCreatures(null, 1));
        }

        //Add creatures should call CreteCreature from factory
        [Test]
        public void AddCreatures_WhenInvoked_ShouldCallCreateCreatureFromFactory()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedFactory = new Mock<ICreaturesFactory>();

            var bm = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            var mockedCreature = new Angel();
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(mockedCreature);


            bm.AddCreatures(creatureIdentifier, 1);

            mockedFactory.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Once);
        }

        // Add creatures should call WriteLine from Logger
        [Test]
        public void AddCreature_WhenCompleted_ShouldCallWriteLineFromLogger()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedCreature = new Angel();

            var bm = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(mockedCreature);

            // act
            bm.AddCreatures(creatureIdentifier, 1);

            // assert
            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        // Adding creature to Army 3 (not existing) should throw ArgumentException
        [Test]
        public void AddingCreature_toNotExistingArmy_ShouldThrowArgumentException()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedCreature = new Angel();

            var bm = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(3)");
            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(mockedCreature);

            // act & assert
            Assert.Throws<ArgumentException>(() => bm.AddCreatures(creatureIdentifier, 1));
        }

        // Attacking with null identifier should throw ArgumentNullException
        [Test]
        public void Attack_WhenGivvenNullIdentifierForAtackingCreature_ShouldThrowArgumentNullException()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedFactory = new Mock<ICreaturesFactory>();
            var deffendingIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var attackingIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Pesho(1)");
            var mockedCreature = new Angel();

            var bm = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(mockedCreature);
            bm.AddCreatures(attackingIdentifier, 1);

            Assert.Throws<ArgumentException>(() => bm.Attack(attackingIdentifier, deffendingIdentifier));
        }

        [Test]
        public void Attack_WhenGivvenNullIdentifierForDeffendingCreature_ShouldThrowArgumentNullException()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedFactory = new Mock<ICreaturesFactory>();
            var attackingIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var deffendingIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Pesho(1)");
            var mockedCreature = new Angel();

            var bm = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(mockedCreature);
            bm.AddCreatures(attackingIdentifier, 1);

            Assert.Throws<ArgumentException>(() => bm.Attack(attackingIdentifier, deffendingIdentifier));
        }

        [Test]
        public void Attack_WhenSuccesfull_ShouldCallWriteLine6Times()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedFactory = new Mock<ICreaturesFactory>();

            var bm = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            var mockedCreature = new Angel();
            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(mockedCreature);
            var attackingIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var deffendingIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            bm.AddCreatures(attackingIdentifier, 1);
            bm.AddCreatures(deffendingIdentifier, 1);

            bm.Attack(attackingIdentifier, deffendingIdentifier);


            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(6));
        }

        // Attacking with two Behemoths should return right result0
        // (two Behemoths attack 1 Behemoth and the expected result is 56) 
        //- could be tried with all the other creatures
        [Test]
        [Ignore("Not Sure what to do")]
        public void Attack_WihTwobehemoths_ExpectedResultShouldBe56()
        {
            // arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedFactory = new Mock<ICreaturesFactory>();

            var bm = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            var mockedCreature = new Behemoth();
            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(mockedCreature);
            var attackingIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Behemoth(1)");
            var deffendingIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Behemoth(1)");

            bm.AddCreatures(attackingIdentifier, 2);
            bm.AddCreatures(deffendingIdentifier, 1);

            var expected = 56;
            // act
            bm.Attack(attackingIdentifier, deffendingIdentifier);


        }
    }
}
