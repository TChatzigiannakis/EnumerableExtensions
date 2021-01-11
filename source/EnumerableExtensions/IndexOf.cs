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
        /// <summary>
        /// Returns the index of the given item in the enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this IEnumerable<T> sequence, T key)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            var index = 0;
            foreach (var e in sequence)
                if (!e.Equals(key))
                    index++;
                else
                    return index;

            throw new KeyNotFoundException();
        }
    }
}
