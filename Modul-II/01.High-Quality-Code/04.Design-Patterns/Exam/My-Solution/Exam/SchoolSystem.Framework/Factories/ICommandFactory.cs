using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Db;

namespace SchoolSystem.Framework.Factories
{
    public interface ICommandFactory
    {
        ICommand GetCreateStudentCommand(IStudentFactory studentFactory);

        ICommand GetCreateTeacherCommand(ITeacherFactory teacherFactory);

        ICommand GetRemoveStudentCommand(IDbProvider dbProvider);

        ICommand GetRemoveTeacherCommand(IDbProvider dbProvider);

        ICommand GetStudentListMarksCommand(IDbProvider dbProvider);

        ICommand GetTeacherAddMarkCommand(IDbProvider dbProvider);
    }
}
