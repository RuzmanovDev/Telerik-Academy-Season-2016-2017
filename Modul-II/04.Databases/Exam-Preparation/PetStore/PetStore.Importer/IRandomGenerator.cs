using System;

namespace PetStore.Importer
{
    public interface IRandomGenerator
    {
        DateTime RandomDateTime(DateTime? after = default(DateTime?), DateTime? before = default(DateTime?));
        int RandomNumber(int min = 0, int max = 1073741823);
        string RandomString(int minLength = 0, int maxLength = 1073741823);
    }
}