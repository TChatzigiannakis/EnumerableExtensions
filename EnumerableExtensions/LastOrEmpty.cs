/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 * 
 * Copyright (C) 2014  Theodoros Chatzigiannakis
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumerableExtensions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns a sequence containing only the last element of a given sequence if such an element exists, or an empty sequence if it doesn't exist.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static IEnumerable<T> LastOrEmpty<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");

            if (sequence.Any())
                return new T[] { sequence.Last() };
            else
                return new T[0];
        }

        /// <summary>
        /// Returns a sequence containing only the last element of a given sequence that satisfies a specified condition if such an element exists, or an empty sequence if it doesn't exist.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> LastOrEmpty<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (predicate == null) throw new ArgumentNullException("predicate");

            return sequence.Where(predicate).LastOrEmpty();
        }
    }
}
