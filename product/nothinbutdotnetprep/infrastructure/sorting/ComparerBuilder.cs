using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        IComparer<ItemToSort> current_comparer;

        public ComparerBuilder(IComparer<ItemToSort> current_comparer)
        {
            this.current_comparer = current_comparer;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return current_comparer.Compare(x, y);
        }

        public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(Func<ItemToSort, PropertyType> func) where PropertyType : IComparable<PropertyType>
        {
           return new ComparerBuilder<ItemToSort>(new ChainedComparer<ItemToSort>(current_comparer, 
               new ReverseComparer<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(func, new ComparableComparer<PropertyType>()))));
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> func) where PropertyType : IComparable<PropertyType>
        {
           return new ComparerBuilder<ItemToSort>(new ChainedComparer<ItemToSort>(current_comparer, 
               new PropertyComparer<ItemToSort, PropertyType>(func, new ComparableComparer<PropertyType>())));
        }

    }
}