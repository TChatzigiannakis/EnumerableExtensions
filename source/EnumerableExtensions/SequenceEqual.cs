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
    using System.ComponentModel;

    /// <summary>
    /// Extension methods supported by <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Determines whether a specified condition is always satisfied when applied to corresponding elements of two sequences.
        /// </summary>
        public static bool SequenceEqual<T1, T2>(
            this IEnumerable<T1> sequence,
            IEnumerable<T2> second,
            Func<T1, T2, bool> predicate)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            if (second == null) throw new ArgumentNullException(nameof(second));

            var iterator1 = sequence.GetEnumerator();
            var iterator2 = second.GetEnumerator();

            while (iterator1.MoveNext())
            {
                if (!iterator2.MoveNext())
                    return false;

                if (!predicate.Invoke(iterator1.Current, iterator2.Current))
                    return false;
            }

            if (iterator2.MoveNext())
                return false;

            return true;
        }

        /// <summary>
        /// Determines whether a specified condition is always satisfied when applied to corresponding elements of two sequences.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool MapsTo<T1, T2>(
            this IEnumerable<T1> items,
            IEnumerable<T2> other,
            Func<T1, T2, bool> predicate) => items.SequenceEqual(other, predicate);
    }
}
