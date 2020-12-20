using System.Threading.Tasks;

namespace College.Core.Interfaces
{

    public interface IRedisCacheDbDal
    {
        Task<string> RetrieveItemFromCache(string itemKey);

        Task<bool> SaveOrUpdateItemToCache(string itemKey, string value);

        Task<bool> DeleteItemFromCache(string itemKey);
    }

}