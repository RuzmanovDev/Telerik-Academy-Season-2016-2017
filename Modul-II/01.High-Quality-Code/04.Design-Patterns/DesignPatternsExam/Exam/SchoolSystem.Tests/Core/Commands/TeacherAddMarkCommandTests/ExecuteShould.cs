using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Db;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Core.Commands.TeacherAddMarkCommandTests
{
    [TestFixture]
    public class ExecuteShould
    {
        [Test]
        public void CallAddMarkMethodOnce_WithRightParameters()
        {
            var db = new Mock<IDbProvider>();
            var mockedTeacher = new Mock<ITeacher>();
            var mockedStudent = new Mock<IStudent>();
            var mockedMark = new Mock<IMark>();

            mockedTeacher.Setup(f => f.FirstName).Returns("Georgi");
            mockedTeacher.Setup(l => l.LastName).Returns("Ganchev");
            mockedTeacher.Setup(s => s.Subject).Returns(Subject.Bulgarian);

            mockedStudent.Setup(f => f.FirstName).Returns("Petar");
            mockedStudent.Setup(l => l.LastName).Returns("Petrov");

            mockedMark.Setup(m => m.Subject).Returns(Subject.Bulgarian);
            mockedMark.Setup(m => m.Value).Returns(6);

            db.Setup(t => t.GetTeacherById(0)).Returns(mockedTeacher.Object);
            db.Setup(s => s.GetStudentById(0)).Returns(mockedStudent.Object);

            var command = new TeacherAddMarkCommand(db.Object);

            command.Execute(new List<string>() { "0", "0", "6" });

            mockedTeacher.Verify(m => m.AddMark(mockedStudent.Object, 6),Times.Once);

        }

        [Test]
        public void ReturnTheCorrectString_WhenTheMarkIsAded()
        {
            var db = new Mock<IDbProvider>();
            var mockedTeacher = new Mock<ITeacher>();
            var mockedStudent = new Mock<IStudent>();
            var mockedMark = new Mock<IMark>();

            mockedTeacher.Setup(f => f.FirstName).Returns("Georgi");
            mockedTeacher.Setup(l => l.LastName).Returns("Ganchev");
            mockedTeacher.Setup(s => s.Subject).Returns(Subject.Bulgarian);

            mockedStudent.Setup(f => f.FirstName).Returns("Petar");
            mockedStudent.Setup(l => l.LastName).Returns("Petrov");

            mockedMark.Setup(m => m.Subject).Returns(Subject.Bulgarian);
            mockedMark.Setup(m => m.Value).Returns(6);

            db.Setup(t => t.GetTeacherById(0)).Returns(mockedTeacher.Object);
            db.Setup(s => s.GetStudentById(0)).Returns(mockedStudent.Object);

            var command = new TeacherAddMarkCommand(db.Object);

            var actualResult = command.Execute(new List<string>() { "0", "0", "6" });
            var expectedResult = $"Teacher Georgi Ganchev added mark 6 to student Petar Petrov in Bulgarian.";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
