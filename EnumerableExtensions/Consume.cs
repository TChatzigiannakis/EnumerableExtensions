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
        /// Immediately enumerates the sequence without returning any result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        public static void Consume<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");

            T value;
            foreach (var a in sequence)
                value = a;
        }
    }
}
