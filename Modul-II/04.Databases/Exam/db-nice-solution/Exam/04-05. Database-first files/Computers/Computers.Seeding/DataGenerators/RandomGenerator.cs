using System;
using System.Text;

namespace Computers.Seeding.DataGenerators
{
    using Contracts;

    public class RandomGenerator : IRandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private Random random;

        public RandomGenerator()
        {
            this.random = new Random();
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var result = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var letterIndex = this.GetRandomNumber(0, Letters.Length - 1);
                var currentChar = Letters[letterIndex];
                result.Append(currentChar);
            }

            return result.ToString();
        }
    }
}
