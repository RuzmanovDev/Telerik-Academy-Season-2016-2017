using Moq;
using NUnit.Framework;
using SchoolSystem.UnitTests.Mocks;
using SchoolSystemLogic.Core;
using SchoolSystemLogic.Models.Providers;

namespace SchoolSystem.UnitTests
{
    [TestFixture]
    public class EngineTests
    {
        
        [Test]
        public void WriteLine_ShouldBeCalledOnce_WhenValidArgumentIsPassed()
        {
            var mockedReader = new Mock<IReader>();
            var mockedWriter = new Mock<IWritter>();
            var enginge = new Engine(mockedReader.Object, mockedWriter.Object);
            var stringMsg = "random";

            enginge.WriteLine(stringMsg);

            mockedWriter.Verify(w => w.WriteLine(stringMsg));
        }
    }
}
