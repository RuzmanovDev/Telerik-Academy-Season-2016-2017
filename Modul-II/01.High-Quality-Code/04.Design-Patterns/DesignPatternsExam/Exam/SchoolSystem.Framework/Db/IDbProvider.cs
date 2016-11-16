using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Db
{
    public interface IDbProvider
    {
        void AddTeacher(int id, ITeacher teacher);

        void RemoveTeacher(int id);

        void RemoveStudent(int id);

        void AddStudent(int id, IStudent student);

        IStudent GetStudentById(int id);

        ITeacher GetTeacherById(int id);

    }
}
