using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class OrderedEnumerable<T>:IEnumerable<T>
    {
        private IEnumerable<T> items;
        private ComparerBuilder<T> comparer;

        public OrderedEnumerable(IEnumerable<T> items, ComparerBuilder<T> comparer)
        {
            this.items = items;
            this.comparer = comparer;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var list = new List<T>(items);

            list.Sort(comparer);

            return list.GetEnumerator();
        }   

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public OrderedEnumerable<T> then_by<PropertyType>(Func<T,PropertyType> func) where PropertyType :IComparable<PropertyType>
        {
            return new OrderedEnumerable<T>(items, comparer.then_by(func));
        }
    }
}