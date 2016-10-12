namespace SchoolSystemLogic.Models.Contracts
{
    public interface ITeacher : IHuman
    {
        /// <summary>
        /// Hold information about the subject which the teacher is teaching.
        /// </summary>
        SubjectType Subject { get; }

        /// <summary>
        /// Provide functionality for adding marks to the student.
        /// </summary>
        /// <param name="student">The student on whom to add the mark.</param>
        /// <param name="mark">The mark to be added.</param>
        void AddMark(IStudent student, IMark mark);
    }
}
