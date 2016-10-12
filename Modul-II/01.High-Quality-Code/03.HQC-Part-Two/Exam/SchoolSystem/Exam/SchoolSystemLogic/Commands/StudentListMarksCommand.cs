using System.Collections.Generic;
using System.Text;
using SchoolSystemLogic.Core;

namespace SchoolSystemLogic.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var indexOfTheStudent = int.Parse(parameters[0]);
            var marks = Engine.Students[indexOfTheStudent].ListMarks();

            var result = new StringBuilder();

            if (marks.Length == 0)
            {
                result.Append("This student has no marks.");
            }
            else
            {
                result.AppendLine("The student has these marks:");
                result.AppendLine(marks);
            }

            return result.ToString();
        }
    }
}
