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
        /// Bypasses a specified number of elements in a sequence and then returns a specified number of elements.
        /// </summary>
        public static IEnumerable<T> Paginate<T>(
            this IEnumerable<T> sequence,
            int skipCount,
            int takeCount)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            return sequence
                .Skip(skipCount)
                .Take(takeCount);
        }

        /// <summary>
        /// Returns a sequence of sequences, each inner sequence containing a specified number of elements at most.
        /// Every page is individually enumerated before it is returned.
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Paginate<T>(
            this IEnumerable<T> sequence,
            int pageLength)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            return PaginateImpl(sequence, pageLength);
        }

        private static IEnumerable<IEnumerable<T>> PaginateImpl<T>(
            IEnumerable<T> sequence,
            int pageLength)
        {
            using var iterator = sequence.GetEnumerator();

                var list = new List<T>();
                while (iterator.MoveNext())
                {
                    list.Add(iterator.Current);
                    if (list.Count != pageLength) continue;

                    yield return list;
                    list = new List<T>();
                }
                if (list.Any())
                    yield return list;
        }
    }
}
