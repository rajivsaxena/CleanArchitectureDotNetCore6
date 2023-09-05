using Drona.AyushmanBharat.Application.Contracts.StateManagement;
using Drona.AyushmanBharat.Cache.Interface;
using Microsoft.Extensions.Logging;


namespace Drona.AyushmanBharat.Infrastructure.Cache
{
    public class CacheProvider : ICacheProvider
    {
        private readonly IRedisCacheProvider _redisCacheProvider;
        private readonly ILogger<CacheProvider> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheProvider" /> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="redisCacheProvider"></param>
        public CacheProvider(ILogger<CacheProvider> logger, IRedisCacheProvider redisCacheProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _redisCacheProvider = redisCacheProvider ?? throw new ArgumentNullException(nameof(redisCacheProvider));
        }

        /// <summary>
        /// To check if the connection is alive 
        /// </summary>
        /// <returns></returns>
        public bool IsAlive()
        {
            try
            {
                return _redisCacheProvider.IsAlive();
            }
            catch (Exception ex)
            {
                _logger.LogError("Redis IsAlive : " + ex.Message, ex.InnerException);
                return false;
            }
        }

        /// <summary>
        /// To flush all keys
        /// </summary>
        /// <returns></returns>
        public bool FlushAll()
        {
            bool hasFlushed = false;
            try
            {
                hasFlushed = _redisCacheProvider.FlushAll();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in FlushAll : " + ex.Message, ex.InnerException);
                hasFlushed = false;
            }
            return hasFlushed;
        }

        /// <summary>
        /// remove cache value with given key Asyncronously, if given key exists else do nothing
        /// </summary>
        /// <param name="key">key name</param>
        public async Task RemoveItemIfExistAsync(string key)
        {
            try
            {
                await _redisCacheProvider.RemoveItemIfExistAsync(key);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in RemoveItemIfExistAsync" + ex.Message, ex.InnerException);
            }
        }

        public async Task<T?> Execute<T>(string key, Func<Task<T>> func, int ttl = 0)
        {
            try
            {
                return await _redisCacheProvider.Execute<T>(key, func, ttl);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Execute" + ex.Message, ex.InnerException);
                return default(T);
            }
        }

        /// <summary>
        /// Get cahced value with given key Asyncronously
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="key">key name</param>
        /// <returns>return value</returns>
        public async Task<T?> GetItemAsync<T>(string key)
        {
            try
            {
                return await _redisCacheProvider.GetItemAsync<T>(key);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in GetItemAsync" + ex.Message, ex.InnerException);
                return default(T);
            }
        }
    }
}
