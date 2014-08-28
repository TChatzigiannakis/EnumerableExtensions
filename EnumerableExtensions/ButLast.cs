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
        /// Returns all elements in a sequence, excluding the last.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static IEnumerable<T> ButLast<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");

            using (var iterator = sequence.GetEnumerator())
            {
                var firstTime = true;
                var previous = default(T);
                while (iterator.MoveNext())
                {
                    if (firstTime)
                    {
                        previous = iterator.Current;
                        firstTime = false;
                    }
                    else
                    {
                        yield return previous;
                        previous = iterator.Current;
                    }
                }
            }
        }
    }
}
