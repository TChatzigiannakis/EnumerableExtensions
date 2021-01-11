/*
 * EnumerableExtensions
 * Copyright (C) 2014-2015  Theodoros Chatzigiannakis
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

namespace EnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns distinct elements from a sequence by using a specified predicate and hash code function to compare values.
        /// </summary>
        public static IEnumerable<T> Distinct<T>(
            this IEnumerable<T> sequence,
            Func<T, T, bool> predicate,
            Func<T, int> hashCodeFunction) =>
                sequence.Distinct(new DistinctEqualityComparer<T>(
                    predicate,
                    hashCodeFunction));

        /// <summary>
        /// Returns distinct elements from a sequence by using a specified predicate to compare values.
        /// </summary>
        public static IEnumerable<T> Distinct<T>(
            this IEnumerable<T> sequence,
            Func<T, T, bool> predicate) => DistinctImpl(
                sequence ?? throw new ArgumentNullException(nameof(sequence)),
                predicate ?? throw new ArgumentNullException(nameof(predicate)));

        private static IEnumerable<T> DistinctImpl<T>(
            IEnumerable<T> sequence,
            Func<T, T, bool> predicate)
        {
            using var iterator = sequence.GetEnumerator();
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

    internal class DistinctEqualityComparer<T> : IEqualityComparer<T>
    {
        public Func<T, T, bool> EqualityPredicate { get; }

        public Func<T, int> HashCodeFunction { get; }

        public DistinctEqualityComparer(
            Func<T, T, bool> equality,
            Func<T, int> hashCode)
        {
            EqualityPredicate = equality ?? throw new ArgumentNullException(nameof(equality));
            HashCodeFunction = hashCode ?? throw new ArgumentNullException(nameof(hashCode));
        }

        public bool Equals(T x, T y) => EqualityPredicate.Invoke(x, y);

        public int GetHashCode(T obj) => HashCodeFunction.Invoke(obj);
    }
}
