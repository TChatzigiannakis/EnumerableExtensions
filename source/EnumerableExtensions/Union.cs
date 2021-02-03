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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods supported by <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns the union of a sequence and a new element.
        /// </summary>
        public static IEnumerable<T> Union<T>(
            this IEnumerable<T> items,
            T newElement) => items.Union(newElement.ToUnarySequence());
    }
}
