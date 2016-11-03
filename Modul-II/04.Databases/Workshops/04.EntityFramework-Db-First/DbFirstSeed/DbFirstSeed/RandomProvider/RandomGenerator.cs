using System;

namespace DbFirstSeed.RandomProvider
{
    public class RandomGenerator : IRandomGenerator
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuwxyz";
        private Random random;

        public RandomGenerator()
        {
            this.random = new Random();
        }

        public DateTime GetRandomDate()
        {
            return DateTime.Now;
        }

        public int GetRandomInt(int min, int max)
        {
            return random.Next(min, max - 1);
        }

        public string GetRandomString(int minLength, int maxLength)
        {
            var strLength = this.GetRandomInt(minLength, maxLength);
            var result = "";

            for (int i = 0; i < strLength; i++)
            {
                result += chars[this.GetRandomInt(0, chars.Length)];
            }

            return result;
        }

    }
}
