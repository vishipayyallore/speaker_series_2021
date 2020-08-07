using StackExchange.Redis;

namespace College.WebAPI.RedisDataStore
{
    public interface ICacheDbContext
    {
        IDatabase RedisCacheDb { get; }
    }
}