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
        /// Returns all elements in a sequence that satisfy a specified condition and the first element that doesn't, if any.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> TakeWhileAndNext<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

	        return TakeWhileAndNextImpl<T>(sequence, predicate);
        }

	    private static IEnumerable<T> TakeWhileAndNextImpl<T>(IEnumerable<T> sequence, Func<T, bool> predicate)
	    {
			foreach (var i in sequence)
			{
				yield return i;
				if (!predicate.Invoke(i))
					yield break;
			}
		}
	}
}
