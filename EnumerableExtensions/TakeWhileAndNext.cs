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
        /// Returns all elements in a sequence that satisfy a specified condition and the first element that doesn't, if any.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> TakeWhileAndNext<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (predicate == null) throw new ArgumentNullException("predicate");

            foreach (var i in sequence)
            {
                yield return i;
                if (!predicate.Invoke(i))
                    yield break;
            }
        }
    }
}
