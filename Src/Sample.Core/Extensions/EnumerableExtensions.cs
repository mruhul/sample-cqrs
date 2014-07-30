using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> NullSafe<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action.Invoke(item);
            }
        }
    }
}