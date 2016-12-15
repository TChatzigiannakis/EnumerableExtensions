/*
 * EnumerableExtensions
 * Copyright (C) 2014-2015  Theodoros Chatzigiannakis
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Linq;
using System.Collections.Generic;

namespace EnumerableExtensions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Filters out all instances equal to the default value of the given sequence.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> RemoveDefaults<T>(this IEnumerable<T> sequence) => typeof(T).IsValueType ? sequence.Except(x => x.Equals (default(T))) : RemoveNull<T> (sequence);

	    /// <summary>
        /// Filters out all null instances from the given sequence.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> RemoveNull<T>(this IEnumerable<T> sequence) => sequence.Except(x => object.ReferenceEquals(x, null));

#pragma warning disable CSE0003 // Use expression-bodied members
	    /// <summary>
        /// Filters out all instances equal to the default value of their own individual type.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> RemoveIndividualDefaults<T>(this IEnumerable<T> sequence)
        {
            return sequence.Except (x => {
                if(object.ReferenceEquals(x, null)) return true;
                if(!x.GetType().IsValueType) return false;
                return x.Equals(Activator.CreateInstance(x.GetType()));
            });
        }
#pragma warning restore CSE0003 // Use expression-bodied members
    }
}

