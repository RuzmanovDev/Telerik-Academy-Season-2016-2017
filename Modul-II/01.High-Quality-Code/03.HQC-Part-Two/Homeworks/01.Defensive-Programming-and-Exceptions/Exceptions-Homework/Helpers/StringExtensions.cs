using System;
using System.Text;

namespace Exceptions_Homework.Helpers
{
    public static class StringExtensions
    {
        public static string ExtractEnding(string str, int count)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException("The value of the string cannot be null!");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("The count must be >= 0");
            }

            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException($"The value of count: {count} must be <= than the string's lenght: {str.Length}");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }
    }
}
