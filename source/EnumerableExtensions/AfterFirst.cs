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
        /// Returns all elements in a sequence that follow the first occurence of an element that satisfies a specified condition.
        /// </summary>
        public static IEnumerable<T> AfterFirst<T>(
            this IEnumerable<T> sequence,
            Func<T, bool> predicate)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            return sequence
                .SkipWhile(x => !predicate.Invoke(x))
                .Skip(1);
        }
    }
}
