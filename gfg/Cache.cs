using System.Collections.Generic;

namespace TrinoWPF.Database
{
    public static class Cache
    {
        private static Dictionary<string, object> _cache = new Dictionary<string, object>();

        public static void Add(string key, object value)
        {
            if (_cache.ContainsKey(key))
                Remove(key);
            _cache.Add(key, value);
        }
        
        public static T Get<T>(string key)
        {
            return (T)_cache[key];
        }

        public static void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}