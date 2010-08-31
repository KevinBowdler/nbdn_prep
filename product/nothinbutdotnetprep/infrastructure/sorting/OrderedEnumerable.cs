using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class OrderedEnumerable<T>:IEnumerable<T>
    {
        private IEnumerable<T> items;
        private IComparer<T> comparer;

        public OrderedEnumerable(IEnumerable<T> items, IComparer<T> comparer)
        {
            this.items = items;
            this.comparer = comparer;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var list = new List<T>(items);

            list.Sort(comparer);

            foreach (var item in list)
            {
                yield return item;
            }
        }   

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public OrderedEnumerable<T> then_by<PropertyType>(Func<T,PropertyType> func) where PropertyType :IComparable<PropertyType>
        {
            return new OrderedEnumerable<T>(items, new ChainedComparer<T>(comparer, new PropertyComparer<T,PropertyType>(func, new ComparableComparer<PropertyType>())));
        }
    }
}