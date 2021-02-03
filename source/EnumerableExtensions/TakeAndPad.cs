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
        /// Returns a specified number of contiguous elements from the start of a sequence and pads with a default defaultValue if the initial sequence was insufficient.
        /// </summary>
        public static IEnumerable<T> TakeAndPad<T>(
            this IEnumerable<T> sequence,
            int count,
            T defaultValue)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            var taken = sequence.Take(count);
            var takenCount = 0;
            foreach (var e in taken)
            {
                yield return e;
                takenCount++;
            }

            for (var i = 0; i < count - takenCount; i++)
                yield return defaultValue;
        }

        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence and pads with a default defaultValue if the initial sequence was insufficient.
        /// </summary>
        public static IEnumerable<T> TakeAndPad<T>(
            this IEnumerable<T> sequence,
            int count) => sequence.TakeAndPad(count, default);
    }
}
