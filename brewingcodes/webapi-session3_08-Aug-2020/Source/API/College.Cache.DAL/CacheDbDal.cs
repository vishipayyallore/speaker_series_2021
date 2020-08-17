using College.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace College.Cache.DAL
{

    public class CacheDbDal : ICacheDbDal
    {
        private readonly ICacheDbContext _cacheDbContext;
        private const string _returnNull = null;

        public CacheDbDal(ICacheDbContext cacheDbContext)
        {
            _cacheDbContext = cacheDbContext;
        }

        public async Task<string> RetrieveItemFromCache(string itemKey)
        {
            try
            {
                var itemFromCache = await _cacheDbContext.RedisDatabase
                                                .StringGetAsync(itemKey);

                if (!itemFromCache.IsNullOrEmpty)
                {
                    return itemFromCache;
                }
            }
            catch (Exception error)
            {
                // ToDo: Log into File.
                Console.WriteLine($"Error occurred at CacheDbDal::RetrieveItemFromCache(). Message: {error.Message}");
            }

            return _returnNull;
        }

        public async Task<bool> SaveOrUpdateItemToCache(string itemKey, string itemValue)
        {
            bool itemSaved = false;

            try
            {
                itemSaved = await _cacheDbContext.RedisDatabase.StringSetAsync(itemKey, itemValue);
            }
            catch (Exception error)
            {
                // ToDo: Log into File.
                Console.WriteLine($"Error occurred at CacheDbDal::SaveItemToCache(). Message: {error.Message}");
            }

            return itemSaved;
        }

        public async Task<bool> DeleteItemFromCache(string itemKey)
        {
            bool itemDeleted = false;

            try
            {
                itemDeleted = await _cacheDbContext.RedisDatabase.KeyDeleteAsync(itemKey);
            }
            catch (Exception error)
            {
                // ToDo: Log into File.
                Console.WriteLine($"Error occurred at CacheDbDal::DeleteItemFromCache(). Message: {error.Message}");
            }

            return itemDeleted;
        }

    }

}
