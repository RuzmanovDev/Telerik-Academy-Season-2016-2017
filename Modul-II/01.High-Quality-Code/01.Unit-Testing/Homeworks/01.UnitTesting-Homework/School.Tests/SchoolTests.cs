namespace School.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void ShooolCtor_WhenPassedValidValues_ShouldCreateSchool()
        {
            var school = new School("SchoolName", new List<Course>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void Name_WhenPassedNUll_ShouldThrowNullReferenceExcpetion()
        {
            var school = new School(null, new List<Course>());
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void Name_WhenPassedEmptyString_ShouldThrowNullReferenceExcpetion()
        {
            var school = new School(string.Empty, new List<Course>());
        }

        [TestMethod]
        public void Name_WhenValidNamesIsPassedToTheCounstructor_ShouldBeAssignedCorrectly()
        {
            var name = "SchoolName";

            var school = new School(name, new List<Course>());

            Assert.AreEqual(name, school.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), AllowDerivedTypes = true)]
        public void AddStudent_WhenStuentsWithEqualIdAreAdded_ShouldThrowArgumentExcpetion()
        {
            var pesho = new Student("pesho", 10000);
            var pesho2 = new Student("pesho", 10000);
            var school = new School("schoolName", new List<Course>());

            school.AddStudent(pesho);
            school.AddStudent(pesho2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void AddStudent_WhenNullIsPassed_ShouldThrowArgumentNullExcpetion()
        {
            var school = new School("pesho", new List<Course>());
            Student pesho = null;

            school.AddStudent(pesho);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
        public void Course_WhenNullCourseAdded_ShouldThrowArgumentNullException()
        {
            List<Course> courses = null;
            var school = new School("pesho", courses);
        }

        [TestMethod]
        public void AddStudent_WhenValidStudentIsAdded_ShouldAddStudentToTheCollectionOfTheSchool()
        {
            var school = new School("pesho", new List<Course>());
            Student pesho = new Student("Pesho",10000);

            school.AddStudent(pesho);

            Assert.IsTrue(school.Students.Count == 1);
        }
    }
}
