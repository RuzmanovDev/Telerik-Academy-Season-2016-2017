using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;
using NUnit.Framework;
using Moq;
using ArmyOfCreatures.UnitTests.Mocks;

namespace ArmyOfCreatures.UnitTests.Logic.Battles
{
    [TestFixture]
    public class CreaturesInBattleTests
    {
        [Test]
        public void DealDamage_WiithNullDefender_ShouldThrowArgumentNullException()
        {
            var creature = new Angel();
            var creatureInBattle = new CreaturesInBattle(creature, 1);

            Assert.Throws<ArgumentNullException>(() => creatureInBattle.DealDamage(null));
        }

        [Test]
        public void DealDamage_WhenCalled_ShouldReturnCorrectResult()
        {
            // arrange
            var atacker = new FakeCreature();
            var deffender = new YetAnotherFakeCreature();
            var creatureInBattle = new CreaturesInBattle(atacker, 1);
            var anotherCreatureInBatlle = new CreaturesInBattle(deffender, 1);

            var expectedHP = 0;

            // act;
            creatureInBattle.DealDamage(anotherCreatureInBatlle);

            //assert
            Assert.AreEqual(expectedHP, anotherCreatureInBatlle.TotalHitPoints);
        }

        [Test]
        public void ToString_WhenCalled_ShouldReturnAsExpected()
        {
            // arrange
            var atacker = new FakeCreature();
            var creatureInBattle = new CreaturesInBattle(atacker, 1);

            var expected = "1 FakeCreature (ATT:10; DEF:10; THP:10; LDMG:0)";
            var actual = creatureInBattle.ToString();

            Assert.AreEqual(expected, actual);
        }

        // Skip should call ApplyOnSkip the count of the specialties times (think about how to make it)
        [Test]
        public void Skip_ShouldCallApllyOnSkipWithTheCountOfTheSpecilties()
        {
            var creature = new FakeCreature();
            var mockedSpecilty = new Mock<Specialty>();
            creature.AddNewSpecialty(mockedSpecilty.Object);

            var creatureInBattle = new CreaturesInBattle(creature, 1);

            creatureInBattle.Skip();

            mockedSpecilty.Verify(x => x.ApplyOnSkip(creatureInBattle), Times.Once);
        }
    }
}
