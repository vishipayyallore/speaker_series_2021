using System.Threading.Tasks;

namespace College.Core.Interfaces
{

    public interface ICacheDbDal
    {
        Task<string> RetrieveItemFromCache(string itemKey);

        Task<bool> SaveOrUpdateItemToCache(string itemKey, string value);

        Task<bool> DeleteItemFromCache(string itemKey);
    }

}