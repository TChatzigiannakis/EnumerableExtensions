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
        /// Returns all elements in a sequence except for the specified one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> sequence, T exception)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");

            return sequence.Except(new[] { exception });
        }

        /// <summary>
        /// Returns all elements in a sequence that do not satisfy a specified condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");

            return sequence.Where(x => !predicate.Invoke(x));
        }
    }
}
