using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;
using Moq;
using NUnit.Framework;

namespace ArmyOfCreatures.UnitTests.Logic.Specialties
{
    [TestFixture]
    public class DoubleDeffenceWhenDeffendingTests
    {
        [Test]
        public void ApplyWhenDefending_WhenDefenderWithSpecialtyIsNull_ShouldThrowArgumentNullException()
        {
            var dd = new DoubleDefenseWhenDefending(1);
            var mockedAtacker = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => dd.ApplyWhenDefending(null, mockedAtacker.Object));
        }

        [Test]
        public void ApplyWhenDefending_WhenAttackerIsNull_ShouldThrowArgumentNullException()
        {
            var dd = new DoubleDefenseWhenDefending(1);
            var mockedDeffender = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => dd.ApplyWhenDefending(mockedDeffender.Object, null));
        }

        //ApplyWhenDefending should return and not change the CurrentDefense property of "defenderWithSpecialty", when the effect is expired.
        [Test]
        public void
            ApplyWhenDeffending_WhenEffectIseExpired_ShouldNOTChangeheCurrentDeffencePropertyOfDeffenderWithSpecialty()
        {
            var dd = new DoubleDefenseWhenDefending(1);
            var creature = new Angel();
            var defender = new CreaturesInBattle(creature, 1);
            defender.CurrentDefense = 10;
            var attacker = new Mock<ICreaturesInBattle>();
            for (int i = 0; i < 1; i++)
            {
                dd.ApplyWhenDefending(defender, attacker.Object);
            }

            Assert.AreEqual(10, defender.CurrentDefense / 2);
        }
        //ApplyWhenDefending should multiply by 2 the CurrentDefense property of "defenderWithSpecialty", when the effect has not expired.

        [Test]
        public void ApplyWhenDefending_WhenEffectIsNotExpired_ShouldDoubleCurrentDeffenceProperyOfheDeffenderWithSpecialty()
        {
            var dd = new DoubleDefenseWhenDefending(1);
            var creature = new Angel();
            var defender = new CreaturesInBattle(creature, 1);
            defender.CurrentDefense = 10;
            var attacker = new Mock<ICreaturesInBattle>();

            for (int i = 0; i < 2; i++)
            {
                dd.ApplyWhenDefending(defender, attacker.Object);
                Assert.AreNotEqual(10, defender.CurrentDefense);
            }
        }
    }
}
