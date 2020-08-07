using StackExchange.Redis;

namespace College.WebAPI.RedisDataStore
{
    public interface ICacheDbContext
    {
        IDatabase RedisDatabase { get; }
    }
}