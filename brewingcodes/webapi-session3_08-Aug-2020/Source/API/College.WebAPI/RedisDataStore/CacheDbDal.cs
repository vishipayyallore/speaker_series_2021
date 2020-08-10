using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.WebAPI.RedisDataStore
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

        public async Task<bool> SaveItemToCache(string itemKey, string itemValue)
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

    }

}
