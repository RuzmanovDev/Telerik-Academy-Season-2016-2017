namespace SchoolSystemLogic.Models.Contracts
{
    public interface IMark
    {
        /// <summary>
        /// Represents the mark value.
        /// </summary>
        float MarkValue { get; }

        /// <summary>
        /// Represents the subject type.
        /// </summary>
        SubjectType SubjectType { get; }
    }
}
