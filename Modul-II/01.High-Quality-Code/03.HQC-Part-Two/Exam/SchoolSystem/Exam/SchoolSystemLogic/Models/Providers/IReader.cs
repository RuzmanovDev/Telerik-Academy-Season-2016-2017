namespace SchoolSystemLogic.Models.Providers
{
    public interface IReader
    {
        /// <summary>
        /// Provides Read method
        /// </summary>
        /// <returns>string that has been read</returns>
        string ReadLine();
    }
}
