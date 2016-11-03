using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed
{
    public class RandomProvider : IRandomProvider
    {
        private Random random;
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public RandomProvider()
        {
            this.random = new Random();
        }


        public string GetRandomString(int minLength, int maxLength)
        {
            var chars = new char[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                chars[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(chars);
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public DateTime? getRandomDate()
        {
            var timeSpan = this.GetRandomNumber(0, 60 * 60 * 24 * 1000);

            return DateTime.Now.AddSeconds(-timeSpan);
        }
    }
}
