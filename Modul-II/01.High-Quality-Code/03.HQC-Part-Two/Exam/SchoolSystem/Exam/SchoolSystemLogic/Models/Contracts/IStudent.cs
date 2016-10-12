using System.Collections.Generic;

namespace SchoolSystemLogic.Models.Contracts
{
    public interface IStudent : IHuman
    {
        /// <summary>
        /// Holds information about which grade is the student in.
        /// </summary>
        Grade Grade { get; }

        /// <summary>
        /// Holds information about the marks of the student.
        /// </summary>
        ICollection<IMark> Marks { get; }

        /// <summary>
        /// Retuns the student marks.
        /// </summary>
        /// <returns>All student marks formated as a string.</returns>
        string ListMarks();
    }
}
