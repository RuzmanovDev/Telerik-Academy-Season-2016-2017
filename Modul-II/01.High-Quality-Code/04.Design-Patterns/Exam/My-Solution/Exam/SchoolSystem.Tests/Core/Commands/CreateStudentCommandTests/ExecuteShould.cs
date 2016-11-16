using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Factories;
using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Db;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.IdGenerators;

namespace SchoolSystem.Tests.Core.Commands.CreateStudentCommandTests
{
    [TestFixture]
    public class ExecuteShould
    {
        [Test]
        public void CallOnlyOnceAddMethodOfDbProvider_WithPassedArguments()
        {
            var studentFactory = new Mock<IStudentFactory>();
            var idGenerator = new Mock<IIdGenerator>();

            var db = new Mock<IDbProvider>();
            var parameters = new List<string>() { "Gosho", "Peshev", "6" };
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);
            var createStudentCommand = new CreateStudentCommand(studentFactory.Object, db.Object,idGenerator.Object);

            var mockedStudent = new Mock<IStudent>();
            studentFactory.Setup(m => m.CreateStudent(firstName, lastName, grade)).Returns(mockedStudent.Object);

            createStudentCommand.Execute(parameters);

            db.Verify(x => x.AddStudent(0, mockedStudent.Object), Times.Once);
        }

        [Test]
        public void CallOnlyOnceCreateStudentMethodOfTheFactory_WithSpecificArguments()
        {
            var studentFactory = new Mock<IStudentFactory>();
            var idGenerator = new Mock<IIdGenerator>();

            var db = new Mock<IDbProvider>();
            var parameters = new List<string>() { "Gosho", "Peshev", "6" };
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);
            var createStudentCommand = new CreateStudentCommand(studentFactory.Object, db.Object,idGenerator.Object);


            createStudentCommand.Execute(parameters);

            studentFactory.Verify(x => x.CreateStudent(firstName, lastName, grade), Times.Once);
        }

        [Test]
        public void ThrowFormatException_WhenArgumentForGradeIsNotParsable()
        {
            var studentFactory = new Mock<IStudentFactory>();
            var idGenerator = new Mock<IIdGenerator>();

            var db = new Mock<IDbProvider>();
            var parameters = new List<string>() { "Gosho", "Peshev", "6!" };
            var firstName = parameters[0];
            var lastName = parameters[1];

            Assert.Throws<FormatException>(() =>
            {
                var grade = (Grade)int.Parse(parameters[2]);
                var command = new CreateStudentCommand(studentFactory.Object, db.Object,idGenerator.Object);
            });
        }

        [Test]
        public void ReturnTheCorrectString_WhenStudentIsAddedSuccesfully()
        {
            var studentFactory = new Mock<IStudentFactory>();
            var db = new Mock<IDbProvider>();
            var parameters = new List<string>() { "Gosho", "Peshev", "6" };
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);
            var idGenerator = new Mock<IIdGenerator>();

            var createStudentCommand = new CreateStudentCommand(studentFactory.Object, db.Object, idGenerator.Object);

            var mockedStudent = new Mock<IStudent>();
            studentFactory.Setup(m => m.CreateStudent(firstName, lastName, grade)).Returns(mockedStudent.Object);

            var actualString = createStudentCommand.Execute(parameters);
            var expectedString = $"A new student with name {firstName} {lastName}, grade {grade} and ID {0} was created.";

            Assert.AreEqual(expectedString, actualString);
        }

    }
}
