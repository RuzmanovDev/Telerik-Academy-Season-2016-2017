using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Factories
{
    public interface ITeacherFactory
    {
        ITeacher CreateTeacher(string firstName, string lastName, Subject subject);
    }
}
