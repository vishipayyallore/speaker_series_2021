using College.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace College.Cache.DAL
{

    public class RedisCacheDbDal : IRedisCacheDbDal
    {
        private readonly IRedisCacheDbContext _cacheDbContext;
        private readonly ILogger<RedisCacheDbDal> _logger;

        public RedisCacheDbDal(IRedisCacheDbContext cacheDbContext, ILogger<RedisCacheDbDal> logger)
        {
            _cacheDbContext = cacheDbContext ?? throw new ArgumentNullException(nameof(cacheDbContext));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> RetrieveItemFromCache(string itemKey)
        {
            var itemFromCache = string.Empty;

            try
            {
                _logger.Log(LogLevel.Debug, "Request Received for RedisCacheDbDal::RetrieveItemFromCache");

                itemFromCache = await _cacheDbContext.RedisDatabase.StringGetAsync(itemKey);

                _logger.Log(LogLevel.Debug, "Returning the results from RedisCacheDbDal::RetrieveItemFromCache");
            }
            catch (Exception error)
            {
                // ToDo: Log into File.
                _logger.Log(LogLevel.Error, $"Error occurred at RedisCacheDbDal::RetrieveItemFromCache(). Message: {error.Message}");
            }

            return itemFromCache;
        }

        public async Task<bool> SaveOrUpdateItemToCache(string itemKey, string itemValue)
        {
            bool itemSavedIntoCache = false;

            try
            {
                _logger.Log(LogLevel.Debug, "Request Received for RedisCacheDbDal::SaveOrUpdateItemToCache");

                itemSavedIntoCache = await _cacheDbContext.RedisDatabase.StringSetAsync(itemKey, itemValue);

                _logger.Log(LogLevel.Debug, "Returning the results from RedisCacheDbDal::SaveOrUpdateItemToCache");
            }
            catch (Exception error)
            {
                // ToDo: Log into File.
                _logger.Log(LogLevel.Error, $"Error occurred at RedisCacheDbDal::SaveItemToCache(). Message: {error.Message}");
            }

            return itemSavedIntoCache;
        }

        public async Task<bool> DeleteItemFromCache(string itemKey)
        {
            bool itemDeletedFromCache = false;

            try
            {
                _logger.Log(LogLevel.Debug, "Request Received for RedisCacheDbDal::DeleteItemFromCache");

                itemDeletedFromCache = await _cacheDbContext.RedisDatabase.KeyDeleteAsync(itemKey);

                _logger.Log(LogLevel.Debug, "Returning the results from RedisCacheDbDal::DeleteItemFromCache");
            }
            catch (Exception error)
            {
                // ToDo: Log into File.
                _logger.Log(LogLevel.Error, $"Error occurred at RedisCacheDbDal::DeleteItemFromCache(). Message: {error.Message}");
            }

            return itemDeletedFromCache;
        }

    }

}
