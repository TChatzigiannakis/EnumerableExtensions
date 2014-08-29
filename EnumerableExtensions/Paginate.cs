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
        /// Bypasses a specified number of elements in a sequence and then returns a specified number of elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="skipCount"></param>
        /// <param name="takeCount"></param>
        /// <returns></returns>
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> sequence, int skipCount, int takeCount)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");

            return sequence.Skip(skipCount).Take(takeCount);
        }

        /// <summary>
        /// Returns a sequence of sequences, each inner sequence containing a specified number of elements at most. Every page is individually enumerated before it is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="pageLength"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Paginate<T>(this IEnumerable<T> sequence, int pageLength)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");

            using (var iterator = sequence.GetEnumerator())
            {
                var list = new List<T>();
                while (iterator.MoveNext())
                {
                    list.Add(iterator.Current);
                    if (list.Count != pageLength) continue;

                    yield return list;
                    list = new List<T>();
                }
                if (list.Any()) 
                    yield return list;
            }
        }
    }
}
