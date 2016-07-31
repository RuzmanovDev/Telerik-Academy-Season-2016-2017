using ArmyOfCreatures.Logic.Battles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class CreatureIdentifierTests
    {
        [Test]
        public void CretureIdentifier_WhenNullIsPassed_ShouldThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CretureIdentifier_WhenInvalidValueToParseIntIsPassed_ShouldThrowsArgumentNullException()
        {
            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel(test)"));
        }

        [Test]
        public void CretureIdentifier_WhenInvalidValueIsPassed_ShouldThrowsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel"));
        }

        [Test]
        public void CretureIdentifier_WhenInvalidValueIsPassed_ToStringShouldReturnExpectedString()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel");
            var result = identifier.ToString();

            Assert.AreEqual("Angel", result);
        }


    }
}
