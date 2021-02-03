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
        /// Filters out all instances equal to the default value of the given sequence.
        /// </summary>
        public static IEnumerable<T> RemoveDefaults<T>(this IEnumerable<T> sequence) =>
            typeof(T).IsValueType
                ? sequence.Except(x => x.Equals(default(T)))
                : RemoveNull(sequence);

        /// <summary>
        /// Filters out all null instances from the given sequence.
        /// </summary>
        public static IEnumerable<T> RemoveNull<T>(this IEnumerable<T> sequence) => sequence.Except(x => x == null);

        /// <summary>
        /// Filters out all instances equal to the default value of their own individual type.
        /// </summary>
        public static IEnumerable<T> RemoveIndividualDefaults<T>(this IEnumerable<T> sequence) =>
            sequence.Except(x =>
            {
                if (x == null) return true;
                if (x.GetType().IsValueType == false) return false;
                return x.Equals(Activator.CreateInstance(x.GetType()));
            });
    }
}

