using StackExchange.Redis;

namespace College.Core.Interfaces
{
    public interface IRedisCacheDbContext
    {
        IDatabase RedisDatabase { get; }
    }
}