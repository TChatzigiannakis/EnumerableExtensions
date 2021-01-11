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
        /// Returns a pseudorandom permutation of a sequence.
        /// </summary>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            var list = sequence.ToList();
            var seq = RandomSequence(0, list.Count());
            return seq.Select(list.ElementAt);
        }

        private static readonly Random RandomNumberGenerator = new Random();

        private static IEnumerable<int> RandomSequence(
            int minimum,
            int maximum)
        {
            var candidates = Enumerable.Range(minimum, maximum - minimum).ToList();
            while (candidates.Count > 0)
            {
                var index = RandomNumberGenerator.Next(candidates.Count);
                yield return candidates[index];
                candidates.RemoveAt(index);
            }
        }
    }
}
