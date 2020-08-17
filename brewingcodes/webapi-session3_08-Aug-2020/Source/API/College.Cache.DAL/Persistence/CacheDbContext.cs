using College.Core.Interfaces;
using StackExchange.Redis;

namespace College.Cache.DAL.Persistence
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
