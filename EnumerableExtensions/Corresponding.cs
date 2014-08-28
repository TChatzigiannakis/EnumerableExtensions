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
        /// Given an element present in a sequence, returns the corresponding (same-indexed) element of another sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="key"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static TResult Corresponding<T, TResult>(this IEnumerable<T> sequence, T key, IEnumerable<TResult> second)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (second == null) throw new ArgumentNullException("second");

            var index = sequence.IndexOf(key);
            return second.ElementAt(index);
        }
    }
}
