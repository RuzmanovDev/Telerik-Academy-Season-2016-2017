namespace SchoolSystemLogic.Models.Providers
{
    public interface IWritter
    {
        /// <summary>
        /// Writes the passed string.
        ///  </summary>
        /// <param name="value">The string to be written.</param>
        void Write(string value);

        /// <summary>
        /// Writes the passed string and adds a new line.
        /// </summary>
        /// <param name="value">The string to be written.</param>
        void WriteLine(string value);

        /// <summary>
        /// Writes the passed char and add new line.
        /// </summary>
        /// <param name="value">The char to be written.</param>
        void Write(char value);

        /// <summary>
        /// Writes the passed char and add new line and adds a new line.
        /// </summary>
        /// <param name="value">The char to be written.</param>
        void WriteLine(char value);
    }
}
