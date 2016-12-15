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
        /// Returns a specified number of contiguous elements from the start of a sequence and pads with a default defaultValue if the initial sequence was insufficient.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="count"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static IEnumerable<T> TakeAndPad<T>(this IEnumerable<T> sequence, int count, T defaultValue)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            var taken = sequence.Take(count);
            var takenCount = 0;
            foreach (var e in taken)
            {
                yield return e;
                takenCount++;
            }

            for (var i = 0; i < count - takenCount; i++)
                yield return defaultValue;
        }

        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence and pads with a default defaultValue if the initial sequence was insufficient.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<T> TakeAndPad<T>(this IEnumerable<T> sequence, int count) => sequence.TakeAndPad(count, default(T));
    }
}
