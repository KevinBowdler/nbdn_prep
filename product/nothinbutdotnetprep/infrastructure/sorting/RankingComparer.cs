using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class RankingComparer<T> : IComparer<T>
    {
        IList<T> rankings;

        public RankingComparer(IEnumerable<T> ranking)
        {
            rankings = new List<T>(ranking);
        }

        public int Compare(T x, T y)
        {
            return rankings.IndexOf(x).CompareTo(rankings.IndexOf(y));
        }
    }
}