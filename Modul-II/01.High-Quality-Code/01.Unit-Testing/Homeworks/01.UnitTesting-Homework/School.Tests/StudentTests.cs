namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentCtor_WhenValidNameIsPassed_ShouldNotThrowExceptions()
        {
            var student = CreateValidStudent();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void StudentConstructor_WhenNullValueIsPassed_ShouldThrowArgumentNullException()
        {
            var student = new Student(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void StudentConstructor_WhenEmptyStringIsPassed_ShouldThrowArgumentNullException()
        {
            var student = new Student(string.Empty, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), AllowDerivedTypes = true)]
        public void StudentId_WhenInvalidIdIsPassed_ShouldThrowException()
        {
            var student = new Student("Pesho", 99999 + 1);
        }

        [TestMethod]
        public void AttendCourse_WhenInvoked_ShouldWork()
        {
            var course = CreateCourse();
            var student = CreateValidStudent();

            student.AttendCourse(course);

            Assert.AreEqual(1, course.Students.Count);
        }
       
        [TestMethod]
        public void LeaveCourse_WhenInvoked_ShouldRemoveTheStudentFromTheCourse()
        {
            var student = CreateValidStudent();
            var course = CreateCourse();

            student.AttendCourse(course);
            student.LeaveCourse(course);

            Assert.AreEqual(0, course.Students.Count);
        }


        // using factory method to initialize valid student
        private Course CreateCourse()
        {
            return new Course("Unit-Testing");
        }

        private Student CreateValidStudent()
        {
            return new Student("Pesho", 10000);
        }
    }
}
