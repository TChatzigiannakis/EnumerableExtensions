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
        /// Returns all elements that satisfy a specified condition or the default value in place of any elements that don't satisfy it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Mask<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

	        return MaskImpl<T>(sequence, predicate);
        }

	    private static IEnumerable<T> MaskImpl<T>(IEnumerable<T> sequence, Func<T, bool> predicate)
	    {
			foreach (var element in sequence)
			{
				if (predicate.Invoke(element))
					yield return element;
				else
					yield return default(T);
			}
		}

		/// <summary>
		/// Returns an IEnumerable where only the items whose zero-based index matches the predicate are present and the rest are replaced by the default value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sequence"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static IEnumerable<T> Mask<T>(this IEnumerable<T> sequence, Func<T, int, bool> predicate)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

			return MaskImpl<T>(sequence, predicate);
        }

	    private static IEnumerable<T> MaskImpl<T>(IEnumerable<T> sequence, Func<T, int, bool> predicate)
	    {
			var index = 0;
			foreach (var element in sequence)
			{
				if (predicate.Invoke(element, index++))
					yield return element;
				else
					yield return default(T);
			}
		}
	}
}
