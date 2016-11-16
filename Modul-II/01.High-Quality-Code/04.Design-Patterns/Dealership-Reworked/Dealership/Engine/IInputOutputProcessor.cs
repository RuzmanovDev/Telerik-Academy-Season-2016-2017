namespace Dealership.Engine
{
    public interface IInputOutputProcessor
    {
        string ReadLine();

        void WriteLine(string str);
    }
}