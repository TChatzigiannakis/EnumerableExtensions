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
        /// Determines whether a sequence is a permutation of another sequence.
        /// </summary>
        public static bool IsPermutationOf<T>(
            this IEnumerable<T> sequence,
            IEnumerable<T> second)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            if (second == null) throw new ArgumentNullException(nameof(second));

            var list1 = sequence.ToList();
            var list2 = second.ToList();

            if (list1.Count == 0 || list2.Count == 0)
                return list1.Count == 0 && list2.Count == 0;

            list1.Sort();
            list2.Sort();

            return list1.SequenceEqual(list2);
        }
    }
}
