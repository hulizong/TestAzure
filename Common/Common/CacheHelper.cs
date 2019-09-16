using System;
using System.Web;
using System.Collections;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Reflection;

namespace Web.Common
{
    public  class CacheHelper
    {
        private static IMemoryCache _memoryCache;

        public CacheHelper(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// 创建绝对过期时间缓存
        /// </summary>
        /// <param name="cacheKey">缓存key</param>
        /// <param name="obj">缓存对象</param>
        /// <param name="expireDate">过期时间（绝对）分钟</param>
        public static  void SetAbsolute(string cacheKey, object obj,int expireDate= 10 * 60)
        {
            //绝对到期时间
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(expireDate));
             
            _memoryCache.Set(cacheKey, obj, cacheEntryOptions);
        }

        /// <summary>
        /// 每隔多长时间不调用就让其过期
        /// </summary>
        /// <param name="cacheKey">缓存key</param>
        /// <param name="obj">缓存对象</param>
        /// <param name="expireDate">过期时间（访问缓存重置时间）</param>
        public static void SetSliding(string cacheKey, object obj, int expireDate= 10 * 60)
        {
            //绝对到期时间
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(expireDate));

            _memoryCache.Set(cacheKey, obj, cacheEntryOptions);
        }

        /// <summary>
        /// 判断缓存是否存在
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        public  static bool IsExist(string cacheKey)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                return false;
            }
            return _memoryCache.TryGetValue(cacheKey, out _);
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="cacheKey">缓存key</param>
        /// <returns>object对象</returns>
        public static object Get(string cacheKey)
        {
            if (string.IsNullOrEmpty(cacheKey))
            {
                return null;
            }
            return  _memoryCache.Get(cacheKey);
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">T对象</typeparam>
        /// <param name="cacheKey">缓存Key</param>
        /// <returns></returns>
        public static  T Get<T>(string cacheKey)
        {
            if (string.IsNullOrEmpty(cacheKey))
            {
                return default(T);
            }
            if (!_memoryCache.TryGetValue<T>(cacheKey, out T cacheEntry))
            {
                return default(T);
            }
            return cacheEntry;
        }

        /// <summary>
        /// 获取所有缓存键
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCacheKeys()
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var entries = _memoryCache.GetType().GetField("_entries", flags).GetValue(_memoryCache);
            var cacheItems = entries as IDictionary;
            var keys = new List<string>();
            if (cacheItems == null) return keys;
            foreach (DictionaryEntry cacheItem in cacheItems)
            {
                keys.Add(cacheItem.Key.ToString());
            }
            return keys;
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">缓存key</param>
        public static  void RemoveCache(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            var keysList = GetCacheKeys();
            foreach (string key in keysList)
            {
                _memoryCache.Remove(key);
            }
        }

    }
}
