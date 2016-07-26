namespace School.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void CourseCtor_WhenAddedValidParameters_ShouldCreateCourse()
        {
            var course = new Course("c#");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),AllowDerivedTypes =true)]
        public void Name_WhenSetToNull_ShouldThrowArgumentNullException()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void Name_WhenSetToEmptyString_ShouldThrowArgumentNullException()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        public void AddStudent_WhenAddedOneStudent_StudentsCountShouldBeOne()
        {
            var course = new Course("C#");
            var student = new Student("Pesho", 10000);
            var expectedResult = 1;

            course.AddStudent(student);

            Assert.AreEqual(expectedResult, course.Students.Count);
        }

        [TestMethod]
        public  void AddStudent_WhenNullIsPassed_ShouldThrowArgumentNullException()
        {

        }
    }
}
