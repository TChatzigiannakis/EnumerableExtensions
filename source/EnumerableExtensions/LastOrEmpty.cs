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

    /// <summary>
    /// Extension methods supported by <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns a sequence containing only the last element of a given sequence if such an element exists, or an empty sequence if it doesn't exist.
        /// </summary>
        public static IEnumerable<T> LastOrEmpty<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            return sequence.Any()
                ? (new T[] { sequence.Last() })
                : (new T[0]);
        }

        /// <summary>
        /// Returns a sequence containing only the last element of a given sequence that satisfies a specified condition if such an element exists, or an empty sequence if it doesn't exist.
        /// </summary>
        public static IEnumerable<T> LastOrEmpty<T>(
            this IEnumerable<T> sequence,
            Func<T, bool> predicate)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return sequence
                .Where(predicate)
                .LastOrEmpty();
        }
    }
}
