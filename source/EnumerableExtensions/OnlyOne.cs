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
        /// Checks whether the sequence contains exactly one element.
        /// </summary>
        public static bool OnlyOne<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            using var iterator = sequence.GetEnumerator();
            return iterator.MoveNext() && !iterator.MoveNext();
        }
    }
}
