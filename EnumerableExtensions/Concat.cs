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
        /// Concatenates a sequence and an element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> sequence, T element)
        {
            return sequence.Concat(element.ToUnarySequence());
        }
    }
}
