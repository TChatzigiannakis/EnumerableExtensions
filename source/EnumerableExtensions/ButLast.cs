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

    /// <summary>
    /// Extension methods supported by <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns all elements in a sequence, excluding the last.
        /// </summary>
        public static IEnumerable<T> ButLast<T>(this IEnumerable<T> sequence) =>
            sequence == null
                ? throw new ArgumentNullException(nameof(sequence))
                : ButLastImpl(sequence);

        private static IEnumerable<T> ButLastImpl<T>(IEnumerable<T> sequence)
        {
            using var iterator = sequence.GetEnumerator();
            if (!iterator.MoveNext()) yield break;
            var previous = iterator.Current;
            while (iterator.MoveNext())
            {
                yield return previous;
                previous = iterator.Current;
            }
        }
    }
}
