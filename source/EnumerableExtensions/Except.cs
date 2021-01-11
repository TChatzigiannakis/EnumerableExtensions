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
        /// Returns all elements in a sequence except for the specified one.
        /// </summary>
        public static IEnumerable<T> Except<T>(
            this IEnumerable<T> sequence,
            T exception)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));

            return default(T) == null
                ? sequence.Except(x => x == null)
                : sequence.Except(x => exception.Equals(x));
        }

        /// <summary>
        /// Returns all elements in a sequence that do not satisfy a specified condition.
        /// </summary>
        public static IEnumerable<T> Except<T>(
            this IEnumerable<T> sequence,
            Func<T, bool> predicate)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            return sequence.Where(x => !predicate.Invoke(x));
        }

        /// <summary>
        /// Returns all elements in a sequence that do not satisfy a specified condition.
        /// Each element's index is used in the logic of the predicate function.
        /// </summary>
        public static IEnumerable<T> Except<T>(
            this IEnumerable<T> sequence,
            Func<T, int, bool> predicate)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            return sequence.Where((x, i) => !predicate.Invoke(x, i));
        }
    }
}
