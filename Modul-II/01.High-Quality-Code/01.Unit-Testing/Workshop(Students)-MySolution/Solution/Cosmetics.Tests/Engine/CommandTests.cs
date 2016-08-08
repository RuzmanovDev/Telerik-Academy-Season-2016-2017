namespace Cosmetics.Tests.Engine
{
    using System;
    using System.Collections.Generic;

    using Cosmetics.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_WhenInputParamIsValid_ShouldReturnNewCommandInstance()
        {
            var validInput = "AddToCategory ForMale Cool";

            var executeCommand = Command.Parse(validInput);

            Assert.IsInstanceOf<Command>(executeCommand);
        }

        [Test]
        public void Parse_WhenInputParamIsNull_ShouldThrowNullReferenceException()
        {

            Assert.Throws<NullReferenceException>(() => Command.Parse(null));
        }

        [Test]
        public void Parse_WhenInputParamIsValid_ShouldCorrectlySetNameProperty()
        {

            var validInput = "AddToCategory ForMale Cool";

            var executeCommand = Command.Parse(validInput);

            var actial = executeCommand.Name;
            var expected = "AddToCategory";

            Assert.AreEqual(expected, actial);
        }

        [Test]
        public void Parse_WhenInputParamIsValid_ShouldCorrectlySetParametersProperty()
        {
            var validInput = "AddToCategory ForMale Cool";

            var executeCommand = Command.Parse(validInput);

            var actial = executeCommand.Parameters;
            var expected = new List<string>() { "ForMale", "Cool" };

            CollectionAssert.AreEqual(expected, actial);
        }

        [Test]
        public void Parse_WhenInputParamHasInvalidName_ShouldThrowArgumentNullExceptionWithCorrectMessage()
        {
            Assert.That(() => Command.Parse(" invaldsa forMale"), Throws.ArgumentNullException.With.Message.Contains("Name"));
        }

        [Test]
        public void Parse_WhenInputParamHasInvalidParameters_ShouldThrowArgumentNullExceptionWithCorrectMessage()
        {
            Assert.That(() => Command.Parse("AddTo "), Throws.ArgumentNullException.With.Message.Contains("List"));

        }
    }
}
