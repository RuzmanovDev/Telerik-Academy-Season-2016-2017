using System;
using System.Linq;
using System.Text;

namespace Seeder
{
    public class RandomProvider : IRandomProvider
    {
        private readonly char[] Alphabet;

        private Random random = new Random();

        public RandomProvider()
        {
            this.Alphabet =
                 Enumerable.Range('A', 26).Select(c => (char)c).Concat(
                 Enumerable.Range('a', 26).Select(c => (char)c).Concat(
                 Enumerable.Range('0', 10).Select(c => (char)c)))
                 .ToArray();
        }

        public int RandomNumber(int min = 0, int max = int.MaxValue / 2)
        {
            if (min > max)
            {
                return random.Next(max, min + 1);
            }

            return random.Next(min, max + 1);
        }

        public string RandomString(int minLength = 0, int maxLength = int.MaxValue / 2)
        {
            var length = RandomNumber(minLength, maxLength);
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(Alphabet[random.Next(0, Alphabet.Length)]);
            }

            return result.ToString();
        }

    }
}
