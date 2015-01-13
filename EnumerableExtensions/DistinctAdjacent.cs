using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumerableExtensions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Removes any adjacent duplicates from the original sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctAdjacent<T>(this IEnumerable<T> sequence)
        {
            if(typeof(T).IsValueType) return sequence.DistinctAdjacent((x, y) => x.Equals(y));
            return sequence.DistinctAdjacent((x, y) => ReferenceEquals(x, y));
        }

        /// <summary>
        /// Removes any adjacent duplicates from the original sequence, comparing them using a specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctAdjacent<T>(this IEnumerable<T> sequence, Func<T, T, bool> predicate)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (predicate == null) throw new ArgumentNullException("predicate");

            using (var iterator = sequence.GetEnumerator())
            {
                T previous;
                if (iterator.MoveNext())
                {
                    previous = iterator.Current;
                    yield return previous;
                }
                else yield break;
                
                while (iterator.MoveNext())
                {
                    var current = iterator.Current;
                    if (predicate(current, previous)) continue;
                    yield return current;
                    previous = current;
                }
            }
        }
    }
}
