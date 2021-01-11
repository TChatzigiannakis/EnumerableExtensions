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

    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Removes any adjacent duplicates from the original sequence.
        /// </summary>
        public static IEnumerable<T> DistinctAdjacent<T>(this IEnumerable<T> sequence) =>
            typeof(T).IsValueType
                ? sequence.DistinctAdjacent((x, y) => x.Equals(y))
                : sequence.DistinctAdjacent((x, y) => ReferenceEquals(x, y));

        /// <summary>
        /// Removes any adjacent duplicates from the original sequence, comparing them using a specified predicate.
        /// </summary>
        public static IEnumerable<T> DistinctAdjacent<T>(
            this IEnumerable<T> sequence,
            Func<T, T, bool> predicate) => DistinctAdjacentImpl(
                sequence ?? throw new ArgumentNullException(nameof(sequence)),
                predicate ?? throw new ArgumentNullException(nameof(predicate)));

        private static IEnumerable<T> DistinctAdjacentImpl<T>(
            IEnumerable<T> sequence,
            Func<T, T, bool> predicate)
        {
            using var iterator = sequence.GetEnumerator();
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
