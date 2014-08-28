/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 * 
 * Copyright (C) 2014  Theodoros Chatzigiannakis
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EnumerableExtensions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Combined with .Type(), returns all elements that are not of a specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static TypeRemovingEnumerable<T> NotOf<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");

            return new TypeRemovingEnumerable<T>(sequence);
        }
    }

    /// <summary>
    /// A helper type returned by the NotOf() extension method, to support the NotOf().Type() syntax.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TypeRemovingEnumerable<T>
    {
        private readonly IEnumerable<T> _enumerable;

        public TypeRemovingEnumerable(IEnumerable<T> e)
        {
            _enumerable = e;
        }

        /// <summary>
        /// Returns all items that don't match the given type.
        /// </summary>
        /// <typeparam name="TRes"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> Type<TRes>()
        {
            return _enumerable.Where(x => !(x is TRes));
        }
    }
}
