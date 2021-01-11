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
        /// Returns every combination of elements from two given sequences.
        /// </summary>
        public static IEnumerable<Tuple<T1, T2>> Cartesian<T1, T2>(
            this IEnumerable<T1> sequence,
            IEnumerable<T2> second)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));
            _ = second ?? throw new ArgumentNullException(nameof(second));

            return
                from e1 in sequence
                from e2 in second
                select new Tuple<T1, T2>(e1, e2);
        }

        /// <summary>
        /// Returns every combination of two elements of the given sequence.
        /// </summary>
        public static IEnumerable<Tuple<T, T>> Cartesian<T>(this IEnumerable<T> sequence) => sequence.Cartesian(sequence);
    }
}
