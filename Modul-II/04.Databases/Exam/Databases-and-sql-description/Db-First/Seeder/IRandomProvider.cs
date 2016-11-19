namespace Seeder
{
    public  interface IRandomProvider
    {
        int RandomNumber(int min = 0, int max = 1073741823);
        string RandomString(int minLength = 0, int maxLength = 1073741823);
    }
}