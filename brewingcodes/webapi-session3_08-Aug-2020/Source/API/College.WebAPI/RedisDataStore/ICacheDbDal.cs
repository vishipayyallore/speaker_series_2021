using System.Threading.Tasks;

namespace College.WebAPI.RedisDataStore
{
    public interface ICacheDbDal
    {
        Task<string> RetrieveItemFromCache(string itemKey);
    }
}