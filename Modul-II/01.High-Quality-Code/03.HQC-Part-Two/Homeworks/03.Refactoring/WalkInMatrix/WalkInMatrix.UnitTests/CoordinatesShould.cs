using System;
using NUnit.Framework;

namespace WalkInMatrix.UnitTests
{
    [TestFixture]
    public class CoordinatesShould
    {
        [Test]
        public void ThrowArgumentException_WhenPassedNegativeValueForRow()
        {
            Assert.Throws<ArgumentException>(() => new Coordinates(-1, 0));
        }

        [Test]
        public void ThrowArgumentException_WhenPassedNegativeValueForCol()
        {
            Assert.Throws<ArgumentException>(() => new Coordinates(0, -1));
        }

        [Test]
        public void ThrowArgumentException_WhenPassedNegativeValueForRow_WithMessageContainingRow()
        {
            Assert.That(() => new Coordinates(-1, 0), Throws.ArgumentException.With.Message.Contains("Row"));
        }

        [Test]
        public void ThrowArgumentException_WhenPassedNegativeValueForRow_WithMessageContainingCol()
        {
            Assert.That(() => new Coordinates(0, -1), Throws.ArgumentException.With.Message.Contains("Col"));
        }
    }
}
