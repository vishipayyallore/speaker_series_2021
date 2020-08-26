using College.Core.Interfaces;
using StackExchange.Redis;

namespace College.Cache.DAL.Persistence
{

    public class RedisCacheDbContext : IRedisCacheDbContext
    {

        public RedisCacheDbContext(ConnectionMultiplexer connectionMultiplexer)
        {
            RedisDatabase = connectionMultiplexer.GetDatabase();
        }

        public IDatabase RedisDatabase { get; }
    }

}
