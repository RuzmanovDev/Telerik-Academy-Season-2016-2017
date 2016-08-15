using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;
using NUnit.Framework;
using Moq;

namespace ArmyOfCreatures.UnitTests.Logic.Battles
{
    [TestFixture]
    public class CreatureIdentifierTests
    {
        //Call with null valueToParse should throw ArgumentNullException
        [Test]
        public void CreatureIdentifierFromString_WithNullValue_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CreatureIdentifierFromString_WithInvalidArmyNumber_ShouldThrowFormatException()
        {
            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel(Pesho)"));
        }

        [Test]
        public void CreatureIdentifierFromString_WithStringWithoutBrackets_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel1"));
        }

        [Test]
        public void ToString_WhenCalled_ShouldReturnExpectedResult()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var expected = "Angel(1)";
            var actual = identifier.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
