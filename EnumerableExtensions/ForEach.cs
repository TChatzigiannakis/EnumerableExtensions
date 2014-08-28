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
    public static  partial class EnumerableExtensions
    {
        /// <summary>
        ///  Applies an action to all elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null) throw new ArgumentNullException("items");
            if (action == null) throw new ArgumentNullException("action");

            foreach (var p in sequence)
                action.Invoke(p);
        }
    }
}
