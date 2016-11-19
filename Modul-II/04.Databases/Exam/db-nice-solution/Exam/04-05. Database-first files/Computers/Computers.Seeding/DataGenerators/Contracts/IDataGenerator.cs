namespace Computers.Seeding.DataGenerators.Contracts
{
    using Data;

    internal interface IDataGenerator
    {
        int Order { get; }

        int Count { get; }

        void Generate(ComputersEntitiesDb db, IRandomGenerator random);
    }
}
