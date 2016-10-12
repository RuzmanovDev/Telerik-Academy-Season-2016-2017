using System;
using NUnit.Framework;
using SchoolSystemLogic.Models;
using SchoolSystemLogic.Models.Contracts;

namespace SchoolSystem.UnitTests
{
    [TestFixture]
    public class MarkClassTests
    {

        [TestCase(7)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(1)]
        public void Ctor_ShouldThrowArgumentException_WhenInvalidParameterForValueIsPassed(float invalidArgument)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IMark mark = new Mark(SubjectType.Bulgarian, invalidArgument);
            });
        }


        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void Ctor_ShouldNotThrowArgumentException_WhenInvalidParameterForValueIsPassed(float validArgument)
        {
            Assert.DoesNotThrow(() =>
            {
                IMark mark = new Mark(SubjectType.Bulgarian, validArgument);
            });
        }
    }
}
