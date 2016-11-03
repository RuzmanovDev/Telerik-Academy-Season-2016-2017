using System;

namespace Seed
{
    public interface IRandomProvider
    {
        int GetRandomNumber(int min, int max);
        string GetRandomString(int minLength, int maxLength);
        DateTime? getRandomDate();
    }
}