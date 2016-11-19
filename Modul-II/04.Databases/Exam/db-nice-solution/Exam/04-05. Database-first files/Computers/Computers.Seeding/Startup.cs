namespace Computers.Seeding
{
    public class Startup
    {
        private static void Main()
        {
            var generatorService = new GeneratorService();
            generatorService.InsertAllTableData();
        }
    }
}
