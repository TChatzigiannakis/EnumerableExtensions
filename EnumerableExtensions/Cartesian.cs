/*
 * EnumerableExtensions
 * Copyright (C) 2014-2015  Theodoros Chatzigiannakis
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumerableExtensions
{
    public static partial class EnumerableExtensions
    {
        // ReSharper disable PossibleMultipleEnumeration

        /// <summary>
        /// Returns every combination of elements from two given sequences.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IEnumerable<Tuple<T1, T2>> Cartesian<T1, T2>(this IEnumerable<T1> sequence, IEnumerable<T2> second)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (second == null) throw new ArgumentNullException("second");

            return
                from e1 in sequence
                from e2 in second
                select new Tuple<T1, T2>(e1, e2);
        }

        /// <summary>
        /// Returns every combination of two elements of the given sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static IEnumerable<Tuple<T, T>> Cartesian<T>(this IEnumerable<T> sequence)
        {
            return sequence.Cartesian(sequence);
        }
    }
}
