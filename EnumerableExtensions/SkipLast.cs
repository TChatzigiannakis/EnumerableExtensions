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
        /// Takes all elements from the sequence, except a count of elements leading up to the last. If the original sequence doesn't have enough elements to skip, an empty sequence is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> sequence, int count)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            if (count < 0) throw new ArgumentException("The count can't be a negative number.");

	        return SkipLastImpl<T>(sequence, count);
        }

	    private static IEnumerable<T> SkipLastImpl<T>(IEnumerable<T> sequence, int count)
	    {
			var buffer = new T[count];
			var index = 0;
			var pastFull = false;
			foreach (var e in sequence)
			{
				if (pastFull)
					yield return buffer[index];
				buffer[index++] = e;
				if (index == count)
				{
					index = 0;
					pastFull = true;
				}
			}
		}
	}
}
