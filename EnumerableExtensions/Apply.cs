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
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EnumerableExtensions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Prepares to apply a specified action to a sequence. Must be followed by a specifier.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static IActionApplyingEnumerable<T> Apply<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            if (action == null) throw new ArgumentNullException(nameof(action));

            return new ActionApplyingEnumerable<T>(sequence, action);
        }

        /// <summary>
        /// Apply the previously specified action to all elements.
        /// </summary>
        /// <param name="sequence"></param>
        /// <typeparam name="T"></typeparam>
        public static void ToAll<T>(this IActionApplyingEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            foreach (var a in sequence.Sequence)
                sequence.Action.Invoke(a);
        }

        /// <summary>
        /// Apply the previously specified action to all elements except for the last one.
        /// </summary>
        /// <param name="sequence"></param>
        /// <typeparam name="T"></typeparam>
        public static void ToAllExceptLast<T>(this IActionApplyingEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            foreach (var a in sequence.Sequence.ButLast())
                sequence.Action.Invoke(a);
        }

        /// <summary>
        /// Apply the previously specified action to all elements and then apply an additional action to the last one.
        /// </summary>
        /// <param name="sequence">Items.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void ToAllAndThenApplyToLast<T>(this IActionApplyingEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            var outer = default(T);
            var any = false;
            foreach (var a in sequence.Sequence)
            {
                outer = a;
                sequence.Action.Invoke(a);
                any = true;
            }
            if(any) action.Invoke(outer);
        }

        /// <summary>
        /// Apply the previously specified action to all elements except the last and then apply a different action to the last one.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static void ToAllWithDifferentLast<T>(this IActionApplyingEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));

            using (var iterator = sequence.Sequence.GetEnumerator())
            {
                var previous = default(T);
                var any = false;
                while (iterator.MoveNext())
                {
                    if(any) sequence.Action.Invoke(previous);
                    previous = iterator.Current;
                    any = true;
                }
                if(any) action.Invoke(previous);
            }
        }
    }

    internal class ActionApplyingEnumerable<T> : IActionApplyingEnumerable<T>
    {
        public IEnumerable<T> Sequence { get; }
        public Action<T> Action { get; }

        public ActionApplyingEnumerable(IEnumerable<T> sequence, Action<T> action)
        {
            Sequence = sequence;
            Action = action;
        }
    }

    /// <summary>
    /// Represents a sequence and an action to be applied to its elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IActionApplyingEnumerable<T> : IFluentInterface
    {
        /// <summary>
        /// Represents the sequence.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<T> Sequence { get; }

        /// <summary>
        /// Represents the action.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Action<T> Action { get; }
    }
}
