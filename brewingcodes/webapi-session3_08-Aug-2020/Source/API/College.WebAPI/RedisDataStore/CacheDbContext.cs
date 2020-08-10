using StackExchange.Redis;

namespace College.WebAPI.RedisDataStore
{

    public class CacheDbContext : ICacheDbContext
    {

        public CacheDbContext(ConnectionMultiplexer connectionMultiplexer)
        {
            RedisDatabase = connectionMultiplexer.GetDatabase();
        }

        public IDatabase RedisDatabase { get; }
    }

}
