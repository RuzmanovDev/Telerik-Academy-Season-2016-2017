using System;

namespace DbFirstSeed.RandomProvider
{
    public interface IRandomGenerator
    {
        int GetRandomInt(int min, int max);
        string GetRandomString(int minLength, int maxLength);
        DateTime GetRandomDate();
    }
}