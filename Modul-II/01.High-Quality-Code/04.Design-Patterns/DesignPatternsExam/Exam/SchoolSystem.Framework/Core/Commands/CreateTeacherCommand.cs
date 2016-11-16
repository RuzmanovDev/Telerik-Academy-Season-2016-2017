using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Factories;
using System;
using SchoolSystem.Framework.Db;
using SchoolSystem.Framework.IdGenerators;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private readonly ITeacherFactory teacherFactory;
        private readonly IDbProvider dbProvider;
        private readonly IIdGenerator idGenerator;

        public CreateTeacherCommand(ITeacherFactory teacherFactory, IDbProvider dbProvider, IIdGenerator idGenerator)
        {
            if (teacherFactory == null)
            {
                throw new ArgumentNullException("Thea teacher factory can not be null!");
            }

            if (dbProvider == null)
            {
                throw new ArgumentNullException("The db provider can not be null!");
            }

            if (idGenerator == null)
            {
                throw new ArgumentNullException("The id generator can not be null!");
            }

            this.teacherFactory = teacherFactory;
            this.dbProvider = dbProvider;
            this.idGenerator = idGenerator;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.teacherFactory.CreateTeacher(firstName, lastName, subject);
            var id = this.idGenerator.GetId;

            this.dbProvider.AddTeacher(id, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {id} was created.";
        }
    }
}
