namespace DITEst
{
    public interface IIOProvider
    {
        string Read();

        void Write(string str);
    }
}
