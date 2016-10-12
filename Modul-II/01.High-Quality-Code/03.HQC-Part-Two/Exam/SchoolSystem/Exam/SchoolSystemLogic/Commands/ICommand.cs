using System.Collections.Generic;

namespace SchoolSystemLogic.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Executes the commands from the list of parameters.
        /// </summary>
        /// <param name="parameters">List of parameters.</param>
        /// <returns>String of the result.</returns>
        string Execute(IList<string> parameters);
    }
}
