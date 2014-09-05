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

            var secondEnumerated = second.ToList();

            return 
                from e1 in sequence                
                from e2 in secondEnumerated
                select new Tuple<T1, T2>(e1, e2);
            
        }
    }
}
