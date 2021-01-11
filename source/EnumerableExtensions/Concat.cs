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

    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Concatenates a sequence and an element.
        /// </summary>
        public static IEnumerable<T> Concat<T>(
            this IEnumerable<T> sequence,
            T element) => sequence
                .Concat(element
                    .ToUnarySequence());
    }
}
