
namespace ArmyOfCreatures.UnitTests.Console.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Console.Commands;

    using NUnit.Framework;
    using Moq;

    [TestFixture]
    public class AddCommandsTests
    {
        [Test]
        public void ProcessCommand_WhenBattleManagerIsNull_ShouldThrowArgumentNullException()
        {
            var addCommand = new AddCommand();
            Assert.Throws<ArgumentNullException>(() => addCommand.ProcessCommand(null, "args", "args", "args"));
        }


        [Test]
        public void ProcessCommand_WhenStringParamsIsNull_ShouldThrowArgumentNullException()
        {
            var addCommand = new AddCommand();
            var mockedBm = new Mock<IBattleManager>();
            Assert.Throws<ArgumentNullException>(() => addCommand.ProcessCommand(mockedBm.Object, null));
        }

        [Test]
        public void ProcessCommand_WhenStringParamsIsLessThanTwoSymbols_ShouldThrowArgumentException()
        {
            var addCommand = new AddCommand();
            var mockedBm = new Mock<IBattleManager>();
            Assert.Throws<ArgumentException>(() => addCommand.ProcessCommand(mockedBm.Object, "args"));
        }

        [Test]
        public void ProcessCommand_WhenCommandIsParssed_ShouldCallIBattleManagerAddCreatures()
        {
            var addCommand = new AddCommand();
            var mockedBm = new Mock<IBattleManager>();
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            mockedBm.Setup(x => x.AddCreatures(creatureIdentifier, 1));
            

            addCommand.ProcessCommand(mockedBm.Object, "1", "Angel(1)");
            mockedBm.Verify(x => x.AddCreatures(It.IsAny<CreatureIdentifier>(), 1), Times.Once);

        }   
    }
}
