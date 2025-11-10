namespace Homakers.API.Data.DBInterface
{
    public interface IDatabaseInitializer
    {
        public void EnsureDatabase(string connectionString);
        public void EnsureDatabaseAndSchema(string connectionString);
        public string SeedDemoDataAsync(string connectionString);
    }
}
