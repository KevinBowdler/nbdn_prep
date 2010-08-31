using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class SortingExtensions
    {
        public static OrderedEnumerable<T> order_by<T, PropertyType>(this IEnumerable<T> items, Func<T, PropertyType> func, params PropertyType[] sortOrder)
        {
            return new OrderedEnumerable<T>(items, Compare<T>.by(func, sortOrder));
        }

    }
}