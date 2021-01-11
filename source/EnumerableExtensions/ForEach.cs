/*
 * EnumerableExtensions
 * Copyright (C) 2014-2015  Theodoros Chatzigiannakis
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

namespace EnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    public static partial class EnumerableExtensions
    {
        /// <summary>
        ///  Applies an action to all elements.
        /// </summary>
        public static void ForEach<T>(
            this IEnumerable<T> sequence,
            Action<T> action)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            foreach (var p in sequence)
                action.Invoke(p);
        }

        /// <summary>
        ///  Applies an action to all elements.
        ///  Each element's index is used in the logic of the action.
        /// </summary>
        public static void ForEach<T>(
            this IEnumerable<T> sequence,
            Action<T, int> action)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            var index = 0;
            foreach (var p in sequence)
                action.Invoke(p, index++);
        }
    }
}
