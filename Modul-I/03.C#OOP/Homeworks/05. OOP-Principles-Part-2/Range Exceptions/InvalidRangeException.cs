namespace Range_Exceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message) : base(message)
        {
        }

        public InvalidRangeException(string message, T start, T end) : base(message)
        {
            this.Start = start;
            this.End = end;
        }

        public T Start { get; private set; }

        public T End { get; private set; }

        public override string Message
        {
            get
            {
                return $"The index must be bigger than {this.Start} and lesser than {this.End}!";
            }
        }
    }
}
