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
        /// Returns the index of the given item in the enumerable.
        /// </summary>
        public static int IndexOf<T>(
            this IEnumerable<T> sequence,
            T key)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));

            var index = 0;
            foreach (var e in sequence)
            {
                if (!e.Equals(key))
                    index++;
                else
                    return index;
            }

            throw new KeyNotFoundException();
        }
    }
}
