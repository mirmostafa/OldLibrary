﻿#region Code Identifications

// Created on     2017/07/29
// Last update on 2017/11/07 by Mohammad Mir mostafa 

#endregion

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Caching;
using Mohammad.Helpers;

namespace Mohammad.Primitives
{
    public class AppCache
    {
        private ObjectCache _CacheContainer;
        private static ObjectCache _DefaultCacheContainer;
        public ObjectCache CacheContainer => this._CacheContainer ?? (this._CacheContainer = new MemoryCache(Guid.NewGuid().ToString()));

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ObjectCache DefaultCacheContainer => _DefaultCacheContainer ?? MemoryCache.Default;

        public object this[string key, DateTime? expirationDate = null]
        {
            get => this.CacheContainer[key];
            set => InnerSetToCache(this.CacheContainer, key, value, expirationDate);
        }

        public AppCache() { }

        public AppCache(ObjectCache cacheContainer)
            : this() => this._CacheContainer = cacheContainer;

        public AppCache(string name)
            : this(new MemoryCache(name)) { }

        private static void InnerSetToCache(ObjectCache cacheContainer, string key, object value, DateTime? expirationDate)
        {
            cacheContainer.Set(new CacheItem(key, value), new CacheItemPolicy {AbsoluteExpiration = expirationDate ?? DateTime.MaxValue});
        }

        public static void InitializeCacheContainer(ObjectCache defaultCacheContainer) { _DefaultCacheContainer = defaultCacheContainer; }
        public static void InitializeCacheContainer(string name) { _DefaultCacheContainer = new MemoryCache(name); }

        public static void Set(string key, object value, DateTime? expirationDate = null)
        {
            InnerSetToCache(DefaultCacheContainer, key, value, expirationDate);
        }

        public static TValue Get<TValue>(string key) => Get(key).To<TValue>();

        public static TValue Get<TValue>(string key, Func<TValue> creator, TValue nullValue = default(TValue))
        {
            return CodeHelper.Lock(() =>
            {
                var result = Get<TValue>(key);
                if (!Equals(nullValue, result))
                    return result;
                Set(key, creator());
                return Get(key).To<TValue>();
            });
        }

        public static object Get(string key) => DefaultCacheContainer[key];
    }
}