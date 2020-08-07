using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.WebAPI.RedisDataStore
{

    public class CacheDbContext : ICacheDbContext
    {

        public CacheDbContext(ConnectionMultiplexer redisConnection)
        {
            RedisCacheDb = redisConnection.GetDatabase();
        }

        public IDatabase RedisCacheDb { get; }
    }

}
