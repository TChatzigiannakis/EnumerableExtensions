/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 * 
 * Copyright (C) 2014  Theodoros Chatzigiannakis
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EnumerableExtensions
{
    /// <summary>
    /// Version 1 methods.
    /// </summary>
    [Obsolete("All functionality is now in the EnumerableExtensions class.")]
    public static class __EnumerableHelpers
    {               
        /// <summary>
        /// Applies an action to all but the last item of the enumerable and a different action to the last.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="butLastAction"></param>
        /// <param name="lastAction"></param>
		[Obsolete("Use Apply().ToAllWithDifferentLast()", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ForEachWithDifferentLast<T>(this IEnumerable<T> items, Action<T> butLastAction,
            Action<T> lastAction)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (butLastAction == null) throw new ArgumentNullException("butLastAction");
            if (lastAction == null) throw new ArgumentNullException("lastAction");

            var firstTime = true;
            var previous = default(T);
            foreach (var current in items)
            {
                if (firstTime)
                    firstTime = false;
                else
                    butLastAction.Invoke(previous);
                previous = current;
            }
            lastAction.Invoke(previous);
        }

        /// <summary>
        /// Applies an action to all items of the enumerable and an additional action to the last.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="butLastAction"></param>
        /// <param name="lastAction"></param>
		[Obsolete("Use Apply().ToAllAndThenApplyToLast()", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ForEachAndAlsoForLast<T>(this IEnumerable<T> items, Action<T> butLastAction,
            Action<T> lastAction)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (butLastAction == null) throw new ArgumentNullException("butLastAction");
            if (lastAction == null) throw new ArgumentNullException("lastAction");

            var any = false;
            var last = default(T);
            foreach (var current in items)
            {
                butLastAction.Invoke(current);
                any = true;
                last = current;
            }
            if(any)
                lastAction.Invoke(last);
        }

        /// <summary>
        /// Applies two actions to all but the last item of the enumerable and only the first action to the last.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        /// <param name="butLastAction"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ForEachButExceptForLast<T>(this IEnumerable<T> items, Action<T> action,
            Action<T> butLastAction)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (action == null) throw new ArgumentNullException("action");
            if (butLastAction == null) throw new ArgumentNullException("butLastAction");

            var firstTime = true;
            var previous = default(T);
            foreach (var current in items)
            {
                if (firstTime)
                    firstTime = false;
                else
                {
                    action.Invoke(previous);
                    butLastAction.Invoke(previous);                                        
                }
                previous = current;
            }
            if(!firstTime)
                action.Invoke(previous);
        }

        /// <summary>
        /// Returns all elements until (and excluding) the specified.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IEnumerable<T> Before<T>(this IEnumerable<T> items, T item)
        {
            return items.TakeWhile(x => !x.Equals(item));
        }
    }
}
