using SchoolSystemLogic.Core;
using SchoolSystemLogic.Models.Providers;

namespace SchoolSystem.UnitTests.Mocks
{
    public class MockedEngine : Engine
    {
        public MockedEngine(IReader reader, IWritter writter)
            : base(reader, writter)
        {
        }

    }
}
