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
        public static ITypeRemovingEnumerable<T> NotOf<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");

            return new TypeRemovingEnumerable<T>(sequence);
        }
    }

    internal class TypeRemovingEnumerable<T> : ITypeRemovingEnumerable<T>
    {
        private readonly IEnumerable<T> _enumerable;

        public TypeRemovingEnumerable(IEnumerable<T> e)
        {
            _enumerable = e;
        }

        public IEnumerable<T> Type<TRes>()
        {
            return _enumerable.Where(x => !(x is TRes));
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITypeRemovingEnumerable<out T> : IFluentInterface
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<T> Type<TRes>();
    }
}
