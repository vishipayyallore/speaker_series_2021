namespace BooksStore.Core.Configuration
{

    public class DataStoreSettings : IDataStoreSettings
    {
        public string SqlServerConnectionString { get; set; } = string.Empty;

        public string RedisConnectionString { get; set; } = string.Empty;
    }

}
