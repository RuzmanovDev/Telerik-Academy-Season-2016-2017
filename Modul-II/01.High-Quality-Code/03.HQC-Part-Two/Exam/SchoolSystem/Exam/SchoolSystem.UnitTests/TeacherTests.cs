using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystemLogic.Models;
using SchoolSystemLogic.Models.Contracts;

namespace SchoolSystem.UnitTests
{
    [TestFixture]
    public class TeacherTests
    {

        [TestCase("RANdomNameTHatHasTOBeMoreThanThirtyOneCharackersLOOOOOONG")]
        [TestCase("Драган")]
        [TestCase("s")]
        public void InstanstiatingTeacher_WithInvalidFirstName_ShouldThrowArgumentException(string invalidFirstName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var teacher = new Teacher(invalidFirstName, "Petrov", SubjectType.Math);
            });
        }

        [TestCase("RANdomNameTHatHasTOBeMoreThanThirtyOneCharackersLOOOOOONG")]
        [TestCase("s")]
        [TestCase("Драганов")]
        public void InstanstiatingStudent_WithInvalidLastName_ShouldThrowArgumentException(string invalidLastName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var teacher = new Teacher("Petar", invalidLastName, SubjectType.Math);
            });
        }

        [Test]
        public void AddMark_ShouldThrowArgumentNullExceptionWhenPassedMarkisNull()
        {
            var teacher = new Teacher("Petar", "Ivanov", SubjectType.Bulgarian);
            var mockedStudent = new Mock<IStudent>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                teacher.AddMark(mockedStudent.Object, null);
            });
        }

        [Test]
        public void AddMark_ShouldThrowArgumentNullExceptionWhenPassedStudentisNull()
        {
            var teacher = new Teacher("Petar", "Ivanov", SubjectType.Bulgarian);
            var mockedMark = new Mock<IMark>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                teacher.AddMark(null, mockedMark.Object);
            });
        }

        [Test]
        public void AddMark_ShoulNotThrowWhenPassedValidMarkAndStudent()
        {
            var teacher = new Teacher("Petar", "Ivanov", SubjectType.Bulgarian);
            var mockedMark = new Mock<IMark>();
            var mockedStudent = new Mock<IStudent>();
            mockedStudent.Setup(st => st.Marks).Returns(new List<IMark>());

            Assert.DoesNotThrow(() =>
            {
                teacher.AddMark(mockedStudent.Object, mockedMark.Object);
            });
        }
    }
}
