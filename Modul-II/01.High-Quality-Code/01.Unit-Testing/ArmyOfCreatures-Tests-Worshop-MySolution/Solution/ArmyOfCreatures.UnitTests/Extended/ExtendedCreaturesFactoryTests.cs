using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Extended;
using ArmyOfCreatures.Logic.Creatures;
using NUnit.Framework;
using Moq;

namespace ArmyOfCreatures.UnitTests.Extended
{
    [TestFixture]
    public class ExtendedCreaturesFactoryTests
    {
        /*
         * CreateCreature should throw ArgumentException with message that contains the string "Invalid creature type",
         *  when a string representing non-existing creature type is passed as a method argument.
            CreateCreature should return the corresponding creature type based on the string that is passed as a method argument. 
            Test with (AncientBehemoth, CyclopsKing, Goblin, Griffin, WolfRaider, and something else for the default case).
*/

        [Test]
        public void CreateCreature_WhenInvalidStringIsPassed_ShouldThrowArgumentExceptionWithMsgContainingInvalidCreatureType()
        {
            var msg = "Invalid creature type";

            var factory = new ExtendedCreaturesFactory();
            Assert.That(() => factory.CreateCreature("InvalidName"), Throws.ArgumentException.With.Message.Contain(msg));
        }

        [TestCase("Angel", typeof(Angel))]
        [TestCase("Archangel", typeof(Archangel))]
        [TestCase("ArchDevil", typeof(ArchDevil))]
        [TestCase("Behemoth", typeof(Behemoth))]
        [TestCase("Devil", typeof(Devil))]
        public void CreateCreature_WhenGivvenValidString_ShouldReturnCorrespondingCreature(string command, Type expectedType)
        {
            var factory = new ExtendedCreaturesFactory();

            var creature = factory.CreateCreature(command);

            Assert.IsInstanceOf(expectedType.GetType(), creature.GetType());
        }
    }
}
