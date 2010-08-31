using System;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class Sort<ItemToSort>
    {
        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(
                new PropertyComparer<ItemToSort, PropertyType>(property_accessor, new ComparableComparer<PropertyType>()));
        }

        public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(
            Func<ItemToSort, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(
            new PropertyComparer<ItemToSort, PropertyType>(property_accessor,
                                                           new ReverseComparer<PropertyType>(
                                                               new ComparableComparer<PropertyType>())));
        }

        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> property_accessor,
                                                                   params PropertyType[] ranking)
        {
            return new ComparerBuilder<ItemToSort>(
                new PropertyComparer<ItemToSort, PropertyType>(property_accessor,
                                                               new RankingComparer<PropertyType>(ranking)));
        }
    }
}