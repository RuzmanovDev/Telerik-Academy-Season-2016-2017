namespace Cosmetics.Tests
{
    using System;
    using NUnit.Framework;
    using Common;
    using System.Collections.Generic;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void ChechIfNull_WhenNullParameterIsPassed_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null));
        }

        [Test]
        public void CheckIfNull_WhenValidParameterIsPassed_ShouldNOTThrowAnyExceptions()
        {
            var list = new List<int>();
            Assert.DoesNotThrow(() => Validator.CheckIfNull(list));
        }

        [Test]
        public void CheckIfNull_WhenNullParameterIsPassed_ShouldThrowExceptionWihAppropriateMessage()
        {
            string actualMessage = "The object cannot be null";
            var ex = Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null, actualMessage));
            string expectedMessage = ex.Message;

            StringAssert.Contains(expectedMessage, actualMessage);

        }

        [TestCase(null)]
        [TestCase("")]
        public void CheckIfStringIsNullOrEmpty_WhenNullOrEmptyStringIsPassed_ShouldThrowNullReferenceException(string str)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(str));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_WhenValidParameterIsPassed_ShouldNotThrowAnyException()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty("not empty string"));
        }

        [TestCase(0, 4)]
        [TestCase(1, 5)]
        [TestCase(1, 10)]
        public void CheckIfStringLengthIsValid_WhenTheLenghtOfTheTextIsNotValid_ShouldThrowIndexOutOfRangeException(int min, int max)
        {
            var str = new string('s', max + 1);
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(str, max, min));
        }

        [TestCase(0, 4)]
        [TestCase(1, 5)]
        [TestCase(1, 10)]
        public void CheckIfStringLengthIsValid_WhenTheLenghtOfTheTextIsValid_ShouldNotThrowException(int min, int max)
        {
            var str = new string('s', max);
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(str, max, min));
        }
   
        // TODO: check for exceptionMessages 
    }

}
