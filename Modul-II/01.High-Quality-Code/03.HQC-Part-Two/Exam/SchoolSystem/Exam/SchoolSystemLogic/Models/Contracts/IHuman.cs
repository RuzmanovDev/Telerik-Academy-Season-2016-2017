namespace SchoolSystemLogic.Models.Contracts
{
    public interface IHuman
    {
        /// <summary>
        /// Represents the first name of the human.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Represents the last name of the human.
        /// </summary>
        string LastName { get; }
    }
}
