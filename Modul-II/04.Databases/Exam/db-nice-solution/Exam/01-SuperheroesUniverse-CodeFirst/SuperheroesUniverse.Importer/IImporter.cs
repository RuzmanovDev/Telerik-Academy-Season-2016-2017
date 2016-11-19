namespace SuperheroesUniverse.Importer
{
    using Data.Common;

    public interface IImporter
    {
        void ImportData(ISuperheroesDataProvider db);
    }
}