using SchoolSystem.Framework.Models.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Db
{
    public class SchoolDbProvider : IDbProvider
    {
        private const string TheKeyWasNotPresentInTheDictionary = "The given key was not present in the dictionary.";
        private IDictionary<int, ITeacher> teachers;
        private IDictionary<int, IStudent> students;

        public SchoolDbProvider()
        {
            this.teachers = new Dictionary<int, ITeacher>();
            this.students = new Dictionary<int, IStudent>();
        }

        public void AddTeacher(int id, ITeacher teacher)
        {
            this.teachers.Add(id, teacher);
        }

        public void RemoveTeacher(int id)
        {
            if (!this.teachers.ContainsKey(id))
            {
                throw new ArgumentException(TheKeyWasNotPresentInTheDictionary);
            }

            this.teachers.Remove(id);
        }

        public void AddStudent(int id, IStudent student)
        {
            this.students.Add(id, student);
        }

        public void RemoveStudent(int id)
        {
            if (!this.students.ContainsKey(id))
            {
                throw new ArgumentException(TheKeyWasNotPresentInTheDictionary);
            }

            this.students.Remove(id);
        }

        public IStudent GetStudentById(int id)
        {
            if (!this.students.ContainsKey(id))
            {
                throw new ArgumentException(TheKeyWasNotPresentInTheDictionary);
            }

            return this.students[id];
        }

        public ITeacher GetTeacherById(int id)
        {
            if (!this.students.ContainsKey(id))
            {
                throw new ArgumentException(TheKeyWasNotPresentInTheDictionary);
            }

            return this.teachers[id];
        }
    }
}
