using System.Collections.Generic;
using SchoolSystemLogic.Core;

namespace SchoolSystemLogic.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            Engine.Students.Remove(int.Parse(parameters[0]));
            string result = $"Student with ID {int.Parse(parameters[0])} was sucessfully removed.";

            return result;
        }
    }
}
