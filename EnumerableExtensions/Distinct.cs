/*
 * EnumerableExtensions
 * Copyright (C) 2014-2015  Theodoros Chatzigiannakis
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumerableExtensions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns distinct elements from a sequence by using a specified predicate and hash code function to compare values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="predicate"></param>
        /// <param name="hashCodeFunction"></param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> sequence, Func<T, T, bool> predicate, Func<T, int> hashCodeFunction)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (predicate == null) throw new ArgumentNullException("predicate");

            return sequence.Distinct(new DistinctEqualityComparer<T>(predicate, hashCodeFunction));
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using a specified predicate to compare values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> sequence, Func<T, T, bool> predicate)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (predicate == null) throw new ArgumentNullException("predicate");

            using (var iterator = sequence.GetEnumerator())
            {
                var list = new List<T>();
                while (iterator.MoveNext())
                {
                    if (list.Any(x => predicate.Invoke(x, iterator.Current))) 
                        continue;

                    list.Add(iterator.Current);
                    yield return iterator.Current;
                }
            }
        }
    }

    internal class DistinctEqualityComparer<T> : IEqualityComparer<T>
    {
        public Func<T, T, bool> EqualityPredicate { get; private set; }
        public Func<T, int> HashCodeFunction { get; private set; }

        public DistinctEqualityComparer(Func<T, T, bool> equality, Func<T, int> hashCode)
        {
            EqualityPredicate = equality;
            HashCodeFunction = hashCode;
        }

        public bool Equals(T x, T y)
        {
            return EqualityPredicate.Invoke(x, y);
        }
        public int GetHashCode(T obj)
        {
            return HashCodeFunction.Invoke(obj);
        }
    }
}
