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

    }

}
