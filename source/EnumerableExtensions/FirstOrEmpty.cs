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
        /// Returns a sequence containing only the first element of a given sequence if such an element exists, or an empty sequence if it doesn't exist.
        /// </summary>
        public static IEnumerable<T> FirstOrEmpty<T>(this IEnumerable<T> sequence) =>
            sequence?.Take(1) ?? throw new ArgumentNullException(nameof(sequence));

        /// <summary>
        /// Returns a sequence containing only the first element of a given sequence that satisfies a specified condition if such an element exists,
        /// or an empty sequence if it doesn't exist.
        /// </summary>
        public static IEnumerable<T> FirstOrEmpty<T>(
            this IEnumerable<T> sequence,
            Func<T, bool> predicate) =>
            sequence
                ?.Where(predicate ?? throw new ArgumentNullException(nameof(predicate)))
                .FirstOrEmpty() ?? throw new ArgumentNullException(nameof(sequence));
    }
}
