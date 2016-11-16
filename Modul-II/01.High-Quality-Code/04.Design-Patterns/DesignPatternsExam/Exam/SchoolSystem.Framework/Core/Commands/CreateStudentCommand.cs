using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Factories;
using System;
using SchoolSystem.Framework.Db;
using SchoolSystem.Framework.IdGenerators;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private readonly IStudentFactory studentFactory;
        private readonly IDbProvider dbProvider;
        private readonly IIdGenerator idGenerator;

        public CreateStudentCommand(IStudentFactory studentFactory, IDbProvider dbProvider, IIdGenerator idGenerator)
        {
            if (studentFactory == null)
            {
                throw new ArgumentNullException("StudentFactory can not be null!");
            }

            if (dbProvider == null)
            {
                throw new ArgumentNullException("The db provider can not be null!");
            }

            if(idGenerator == null)
            {
                throw new ArgumentNullException("The id generator can not be null!");
            }

            this.studentFactory = studentFactory;
            this.dbProvider = dbProvider;
            this.idGenerator = idGenerator;
        }
        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.studentFactory.CreateStudent(firstName, lastName, grade);
            var id = this.idGenerator.GetId;
            dbProvider.AddStudent(id, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {id} was created.";
        }
    }
}
