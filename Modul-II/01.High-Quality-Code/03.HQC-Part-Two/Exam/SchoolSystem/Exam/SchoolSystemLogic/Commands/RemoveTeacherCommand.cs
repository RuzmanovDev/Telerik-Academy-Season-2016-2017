using System.Collections.Generic;
using SchoolSystemLogic.Core;

namespace SchoolSystemLogic.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            Engine.Teachers.Remove(int.Parse(parameters[0]));
            string result = $"Teacher with ID {int.Parse(parameters[0])} was sucessfully removed.";

            return result;
        }
    }
}
