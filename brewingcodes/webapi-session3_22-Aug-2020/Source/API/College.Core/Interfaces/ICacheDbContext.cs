using StackExchange.Redis;

namespace College.Core.Interfaces
{
    public interface ICacheDbContext
    {
        IDatabase RedisDatabase { get; }
    }
}