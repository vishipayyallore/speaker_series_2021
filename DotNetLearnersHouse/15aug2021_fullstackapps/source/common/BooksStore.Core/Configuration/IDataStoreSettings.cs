namespace BooksStore.Core.Configuration
{

    public interface IDataStoreSettings
    {
        string RedisConnectionString { get; }

        string SqlServerConnectionString { get; }
    }

}
