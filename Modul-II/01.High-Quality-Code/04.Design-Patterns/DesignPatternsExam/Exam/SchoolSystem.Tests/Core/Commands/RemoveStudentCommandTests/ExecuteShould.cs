using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Db;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Core.Commands.RemoveStudentCommandTests
{
    [TestFixture]
    public class ExecuteShould
    {
        [Test]
        public void ReturnTheCorrectString_WhenTheRightStudentWasRemoved()
        {
            var parameters = new List<string>() { "0" };
            var dbProvider = new Mock<IDbProvider>();

            var removeStudentCommand = new RemoveStudentCommand(dbProvider.Object);
            var epxectedString = "Student with ID 0 was sucessfully removed.";
            var returnedString = removeStudentCommand.Execute(parameters);

            Assert.AreEqual(epxectedString, returnedString);
        }

        [Test]
        public void ThrowFormatException_WhenFirstArgumentCantBeParsed()
        {
            var parameters = new List<string>() { "0w" };
            var dbProvider = new Mock<IDbProvider>();

            var removeStudentCommand = new RemoveStudentCommand(dbProvider.Object);

            Assert.Throws<FormatException>(() => removeStudentCommand.Execute(parameters));
        }
    }
}
