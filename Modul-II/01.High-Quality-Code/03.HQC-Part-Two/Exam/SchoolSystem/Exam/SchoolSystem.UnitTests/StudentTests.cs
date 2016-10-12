using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SchoolSystemLogic.Models;
using SchoolSystemLogic.Models.Contracts;

namespace SchoolSystem.UnitTests
{
    [TestFixture]
    public class StudentTests
    {
        [TestCase("RANdomNameTHatHasTOBeMoreThanThirtyOneCharackersLOOOOOONG")]
        [TestCase("Драган")]
        [TestCase("s")]
        public void InstanstiatingStudent_WithInvalidFirstName_ShouldThrowArgumentException(string invalidFirstName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var student = new Student(invalidFirstName, "Petrov", Grade.Eleventh);
            });
        }

        [TestCase("RANdomNameTHatHasTOBeMoreThanThirtyOneCharackersLOOOOOONG")]
        [TestCase("s")]
        [TestCase("Драганов")]
        public void InstanstiatingStudent_WithInvalidLastName_ShouldThrowArgumentException(string invalidLastName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var student = new Student("Pesho", invalidLastName, Grade.Eleventh);
            });
        }


        [TestCase(-1)]
        [TestCase(13)]
        [TestCase(0)]
        public void InstansiationStudentWithInvalidGrade_SholdThrowArgumentException(int invalidGrade)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var student = new Student("Petar", "Ivanov", (Grade)invalidGrade);
            });
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(6)]
        public void InstansiationStudentWithValidGrade_SholdNotThrowArgumentException(int validGrade)
        {
            var student = new Student("Petar", "Ivanov", (Grade)validGrade);
            var actual = student.Grade;
            var expected = (Grade)validGrade;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ListMarks_ShouldReturnMarksInCorectFormat()
        {
            var student = new Student("Petar", "Ivanov", Grade.Fifth);

            var mockedMark = new Mock<IMark>();
            mockedMark.Setup(m => m.MarkValue).Returns(2);
            mockedMark.Setup(m => m.SubjectType).Returns(SubjectType.Bulgarian);
            var lisOfMarks = new List<IMark>() {mockedMark.Object};
            student.Marks = lisOfMarks;

            var expected = "Bulgarian => 2";
            var actual = student.ListMarks();

            Assert.AreEqual(expected, actual);
        }
    }
}
