using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorm
{
    static class utils
    {
        public static V SetDefault<K, V>(this IDictionary<K, V> dict, K key, V @default)
        {
            V value;
            if (!dict.TryGetValue(key, out value))
            {
                dict.Add(key, @default);
                return @default;
            }
            else
            {
                return value;
            }
        }
    }
}
