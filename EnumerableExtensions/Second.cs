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
        /// Returns the second item of a sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static T Second<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");

            return sequence.Skip(1).First();
        }

        /// <summary>
        /// Returns the second item in a sequence that satisfies a specified condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T Second<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (predicate == null) throw new ArgumentNullException("predicate");

            return sequence.Where(predicate.Invoke).Skip(1).First();
        }
    }
}
