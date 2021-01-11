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
        /// Given an element present in a sequence, returns the corresponding (same-indexed) element of another sequence.
        /// </summary>
        public static TResult Corresponding<T, TResult>(
            this IEnumerable<T> sequence,
            T key,
            IEnumerable<TResult> second)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));
            _ = second ?? throw new ArgumentNullException(nameof(second));

            return second.ElementAt(sequence.IndexOf(key));
        }
    }
}
