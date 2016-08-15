namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Logic.Battles;
    using Moq;
    using Logic;

    // USING MOQ.PROTECTED - testing protected fields and methods


    [TestFixture]
    public class BattleManagerTests
    {
        [Test]
        public void Constructor()
        {
            var mockedCreaturesFacory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var bm = new BattleManager(mockedCreaturesFacory.Object, mockedLogger.Object);

            var wrappedBattleManager = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(bm);

            // var creatuesFactory = 
        }

        [Test]
        public void AddCreatures_WhenCreatureIdentifierIsNull_ShouldThrowArgumentNullException()
        {
            var mockedCreaturesFacory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var bm = new BattleManager(mockedCreaturesFacory.Object, mockedLogger.Object);

            Assert.Throws<ArgumentNullException>(() => bm.AddCreatures(null, 2));
        }

        [Test]
        public void add()
        {

            var mockedCreaturesFacory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();
            var creature = new Logic.Creatures.Angel();
            var bm = new BattleManager(mockedCreaturesFacory.Object, mockedLogger.Object);

            mockedCreaturesFacory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);
        }

        [Test]
        public void ATACK_test()
        {
            var 
        }
    }
}
