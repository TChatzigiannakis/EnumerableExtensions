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
    using System.ComponentModel;

    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Filters out elements of a given type. Must be followed by an additional operator.
        /// </summary>
        public static ITypeRemovingEnumerable<T> NotOf<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
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

        public IEnumerable<T> Type<TRemove>() =>
            _enumerable
                .Except(x => x is TRemove);

        public IEnumerable<T> Type<TRemoveA, TRemoveB>() =>
            _enumerable
                .Except(x => x is TRemoveA)
                .Except(x => x is TRemoveB);

        public IEnumerable<T> Type<TRemoveA, TRemoveB, TRemoveC>() =>
            _enumerable
                .Except(x => x is TRemoveA)
                .Except(x => x is TRemoveB)
                .Except(x => x is TRemoveC);

        public IEnumerable<T> ExactType<TRemove>() =>
            _enumerable
                .Except(x => x.GetType() == typeof(TRemove));

        public IEnumerable<T> ExactType<TRemoveA, TRemoveB>() =>
            _enumerable
                .Except(x => x.GetType() == typeof(TRemoveA))
                .Except(x => x.GetType() == typeof(TRemoveB));

        public IEnumerable<T> ExactType<TRemoveA, TRemoveB, TRemoveC>() =>
            _enumerable
                .Except(x => x.GetType() == typeof(TRemoveA))
                .Except(x => x.GetType() == typeof(TRemoveB))
                .Except(x => x.GetType() == typeof(TRemoveC));

        public IEnumerable<T> AnyClassType() =>
            _enumerable
                .Except(x => x.GetType().IsClass);

        public IEnumerable<T> AnyStructType() =>
            _enumerable
                .Except(x => x.GetType().IsValueType);

        public IEnumerable<T> AnyEnumType() =>
            _enumerable
                .Except(x => x.GetType().IsEnum);
    }

    /// <summary>
    /// Intermediate object to aid in removing elements by type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITypeRemovingEnumerable<out T> : IFluentInterface
    {
        /// <summary>
        /// Filters out all elements that can be assigned to the given type.
        /// </summary>
        IEnumerable<T> Type<TRemove>();

        /// <summary>
        /// Filters out all elements that can be assigned to any of the given types.
        /// </summary>
        IEnumerable<T> Type<TRemoveA, TRemoveB>();

        /// <summary>
        /// Filters out all elements that can be assigned to any of the given types.
        /// </summary>
        IEnumerable<T> Type<TRemoveA, TRemoveB, TRemoveC>();

        /// <summary>
        /// Filters out all elements that are exactly of the given type.
        /// </summary>
        IEnumerable<T> ExactType<TRemove>();

        /// <summary>
        /// Filters out all elements that are exactly of one of the given types.
        /// </summary>
        IEnumerable<T> ExactType<TRemoveA, TRemoveB>();

        /// <summary>
        /// Filters out all elements that are exactly of one of the given types.
        /// </summary>
        IEnumerable<T> ExactType<TRemoveA, TRemoveB, TRemoveC>();

        /// <summary>
        /// Filters out all elements that are instances of a class.
        /// </summary>
        IEnumerable<T> AnyClassType();

        /// <summary>
        /// Filters out all elements that are instances of a struct.
        /// </summary>
        IEnumerable<T> AnyStructType();

        /// <summary>
        /// Filters out all elements that are instances of an enum.
        /// </summary>
        IEnumerable<T> AnyEnumType();
    }
}
