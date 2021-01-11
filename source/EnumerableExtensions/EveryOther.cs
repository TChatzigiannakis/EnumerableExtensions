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
        /// Returns all even-indexed elements in a sequence.
        /// </summary>
        public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> sequence)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));

            var index = 0;
            return sequence.Where(n => index++ % 2 == 0);
        }

        /// <summary>
        /// Returns all even-indexed elements in a sequence of elements that satisfy a specified constraint.
        /// </summary>
        public static IEnumerable<T> EveryOther<T>(
            this IEnumerable<T> sequence,
            Func<T, bool> predicate)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            return sequence
                .Where(predicate)
                .EveryOther();
        }
    }
}
