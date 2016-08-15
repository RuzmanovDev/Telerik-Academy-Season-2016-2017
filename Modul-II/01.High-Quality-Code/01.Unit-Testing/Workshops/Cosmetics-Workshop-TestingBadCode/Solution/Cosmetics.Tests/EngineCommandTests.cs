namespace Cosmetics.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Engine;

    [TestFixture]
    public class EngineCommandTests
    {
        [TestCase("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma")]
        [TestCase("CreateToothpaste White++++ ColgateColgateColgateColgate 15.50 men fluor,bqla,golqma")]
        [TestCase("CreateCategory ForMale")]
        public void Parse_WhenValidInputIsPassed_ShouldNotThrowException(string input)
        {
            Assert.DoesNotThrow(() => Command.Parse(input));
        }

        [Test]
        public void Parse_WhenEmptyStringIsPassed_ShouldThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(""));
            var expected = "Name";
            StringAssert.Contains(expected, ex.Message);
        }

        [Test]
        public void Parse_WhenNulltringIsPassed_ShouldThrowNullRefferenceException()
        {
            Assert.Throws<NullReferenceException>(() => Command.Parse(null));
        }

        [TestCase(null + " White+ Colgate 15.50 men fluor,bqla,golqma")]
        [TestCase("" + " White++++ ColgateColgateColgateColgate 15.50 men fluor,bqla,golqma")]
        public void Parse_WhenNullOrEmptyCommandNameIsPassed_ShouldThrowArgumentNullExceptionWithAMessageThatCointainsName(string command)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(command));
            var expectedString = "Name";

            StringAssert.Contains(expectedString, ex.Message);

        }

        [Test]
        public void Parse_WhenTheInputStringIsValid_ShouldSetCorrectValuesToTheNames()
        {
            string validCommand = "CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma";
            var commandList = Command.Parse(validCommand);

            var commandName = commandList.Name;
            var expectedName = "CreateToothpaste";

            Assert.AreEqual(expectedName, commandName);
        }

        [Test]
        public void Parse_WhenTheInputStringIsValid_ShouldSetCorrectValuesToTheParameters()
        {
            string validCommand = "CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma";
            var commandList = Command.Parse(validCommand);
            var commandName = commandList.Name;

            var parameters = commandList.Parameters;
            var expectedParameters = validCommand.Substring(commandName.Length).Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

            bool areEqual = true;

            for (int i = 0; i < parameters.Count; i++)
            {
                if (parameters[i] != expectedParameters[i])
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.True(areEqual);
        }

        [Test]
        public void Parse_WhenTheCommandListIsNull_ShouldThrowArgumentNullExceptionWithMsgContainingList()
        {
            string invalid = "CreateToothpaste " + null;
            var expectedMsg = "List";

            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(invalid));

            StringAssert.Contains(expectedMsg, ex.Message);

        }
        
    }
}

