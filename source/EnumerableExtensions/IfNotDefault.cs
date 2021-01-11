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

    /// <summary>
    /// Extension methods supported by <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Invokes the action on the given class instance if it's not null, otherwise does nothing.
        /// </summary>
        public static void IfNotDefault<T>(
            this T item,
            Action<T> action)
            where T : class
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));
            action.Invoke(item);
        }
    }
}
