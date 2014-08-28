/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

/// Author:
/// Theodoros Chatzigiannakis

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EnumerableExtensions
{
    /// <summary>
    /// A collection of useful extension methods for the generic IEnumerable.
    /// </summary>
    public static class EnumerableHelpers
    {
        /// <summary>
        /// Returns the first item matching the predicate, between the previous and the next item in the enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Around<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (predicate == null) throw new ArgumentNullException("predicate");

			var array = new T[3];

			using (var iterator = items.GetEnumerator ()) {
				while (iterator.MoveNext () && !predicate (iterator.Current))
					array [0] = iterator.Current;
				array [1] = iterator.Current;
				if (iterator.MoveNext ())
					array [2] = iterator.Current;
			}

			return array;
        }

        /// <summary>
        /// Returns the second item of the sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static T Second<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            return items.Skip(1).First();
        }

        /// <summary>
        /// Returns the second item that matches the predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T Second<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (predicate == null) throw new ArgumentNullException("predicate");

            return items.Where(predicate.Invoke).Skip(1).First();
        }

        /// <summary>
        /// Returns the items of the given enumerable that come before the first match of the predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> TakeUntilFirst<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (predicate == null) throw new ArgumentNullException("predicate");

            return items.TakeWhile(x => !predicate.Invoke(x));
        }

        /// <summary>
        /// Returns the items of the given enumerable that come after the first match of the predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> TakeAfterFirst<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (predicate == null) throw new ArgumentNullException("predicate");

            return items.SkipWhile(x => !predicate.Invoke(x)).Skip(1);
        }

        /// <summary>
        /// Returns the previous of the first item that matches the predicate, or a default value if there is no previous item or if the predicate is not matched.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public static T PreviousOf<T>(this IEnumerable<T> items, Predicate<T> match)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (match == null) throw new ArgumentNullException("match");

            return items.Around(match).First();
        }

        /// <summary>
        /// Returns the next of the first item that matches the predicate, or a default value if there is no next item or if the predicate is not matched.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public static T NextOf<T>(this IEnumerable<T> items, Predicate<T> match)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (match == null) throw new ArgumentNullException("match");

            return items.Around(match).Last();
        }

        /// <summary>
        /// Skips an amount of items, then takes another amount.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> items, int skip, int take)
        {
            if (items == null) throw new ArgumentNullException("items");

            return items.Skip(skip).Take(take);
        }

        /// <summary>
        ///  Applies an action to all items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (action == null) throw new ArgumentNullException("action");

            foreach (var p in items)
                action.Invoke(p);
        }

        /// <summary>
        /// Returns all items whose zero-based index in the IEnumerable predicate the predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIndex<T>(this IEnumerable<T> items, Predicate<int> match)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (match == null) throw new ArgumentNullException("match");

            var index = 0;
            return items.Where(x => match.Invoke(index++));
        }

        /// <summary>
        /// Returns all items whose zero-based index in the IEnumerable is even.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> EveryOther<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            var index = 0;
            return items.Where(n => index++ % 2 == 0);

        }

        /// <summary>
        /// Returns all items whose zero-based index in the IEnumerable is odd.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> EveryOtherAfterFirst<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            var index = 0;
            return items.Where(n => index++ % 2 == 1);
        }

        /// <summary>
        /// Returns an IEnumerable where only the items matching the predicate are present and the rest are replaced by the default value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public static IEnumerable<T> Mask<T>(this IEnumerable<T> items, Predicate<T> match)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (match == null) throw new ArgumentNullException("match");

            foreach (var element in items)
            {
                if (match.Invoke(element))
                    yield return element;
                else
                    yield return default(T);
            }
        }

        /// <summary>
        /// Returns an IEnumerable where only the items whose zero-based index matches the predicate are present and the rest are replaced by the default value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public static IEnumerable<T> MaskIndex<T>(this IEnumerable<T> items, Predicate<int> match)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (match == null) throw new ArgumentNullException("match");

            var index = 0;
            foreach (var element in items)
            {
                if (match.Invoke(index++))
                    yield return element;
                else
                    yield return default(T);
            }
        }

        /// <summary>
        /// Returns all items except the default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> RemoveDefaults<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            return items.Where(x => !x.Equals(default(T)));
        }

        /// <summary>
        /// Returns all items except the first.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> ButFirst<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            return items.Skip(1);
        }

        /// <summary>
        /// Returns all items except the last.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> ButLast<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            using (var iterator = items.GetEnumerator())
            {
                var firstTime = true;
                var previous = default(T);
                while (iterator.MoveNext())
                {
                    if (firstTime)
                    {
                        previous = iterator.Current;
                        firstTime = false;
                    }
                    else
                    {
                        yield return previous;
                        previous = iterator.Current;
                    }
                }
            }

        }

        /// <summary>
        /// Returns an enumerable containing either the first item or nothing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> FirstIfAny<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            return items.Take(1);
        }

        /// <summary>
        /// Returns an enumerable containing either the first item matching the predicate or nothing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> FirstIfAny<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (predicate == null) throw new ArgumentNullException("predicate");

            return items.Where(predicate.Invoke).Take(1);
        }
        
        /// <summary>
        /// Returns an enumerable containing either the last item or nothing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> LastIfAny<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            return new List<T> {items.Last()};
        }

        /// <summary>
        /// Returns an enumerable containing either the last item matching a predicate or nothing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> LastIfAny<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (predicate == null) throw new ArgumentNullException("predicate");

            var matches = items.Where(predicate.Invoke).ToList();
            return !matches.Any() ? new List<T>() : new List<T> {matches.Last()};
        }

        /// <summary>
        /// Applies an action to all but the last item of the enumerable and a different action to the last.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="butLastAction"></param>
        /// <param name="lastAction"></param>
		[Obsolete("Use Apply().ToAllWithDifferentLast()")]
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
		[Obsolete("Use Apply().ToAllAndThenApplyToLast()")]
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
        /// Returns true if and only if there is exactly one item in the enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool OnlyOne<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            return items.Count() == 1;
        }

        /// <summary>
        /// Returns an enumerable containing all the elements of the original except the given one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, T exception)
        {
            if (items == null) throw new ArgumentNullException("items");

            return items.Except(new[] {exception});
        }

        /// <summary>
        /// Returns an enumerable containing only the elements of the original that don't match the predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, Predicate<T> predicate){
            if(items == null) throw new ArgumentNullException("items");

            return items.Where(x => !predicate.Invoke(x));
        }

        /// <summary>
        /// Returns true if and only if there is more than one item in the enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool MoreThanOne<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            return items.Count() > 1;
        }

        /// <summary>
        /// Returns true if and only if all elements in the enumerable are equal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool AllEqual<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            return items.Distinct().Count() == 1;
        }

        /// <summary>
        /// Combined with .Type(), returns all items that don't match a given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static TypeRemovingEnumerable<T> NotOf<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            return new TypeRemovingEnumerable<T>(items);
        }

        /// <summary>
        /// Returns the index of the given item in the enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this IEnumerable<T> items, T key)
        {
            if (items == null) throw new ArgumentNullException("items");

            var index = 0;
            foreach (var e in items)
                if (!e.Equals(key))
                    index++;
                else
                    return index;

            throw new KeyNotFoundException();
        }
        
        /// <summary>
        /// Given two enumerables and a key present in the first enumerable, returns the corresponding item (that is, the item at the same index) of the other enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="items"></param>
        /// <param name="key"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static TResult Corresponding<T, TResult>(this IEnumerable<T> items, T key, IEnumerable<TResult> other)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (other == null) throw new ArgumentNullException("other");

            var index = items.IndexOf(key);
            return other.ElementAt(index);
        }

        /// <summary>
        /// Returns true if and only if every item of the given enumerable and every corresponding item of the other enumerable match a predicate.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="items"></param>
        /// <param name="other"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool SequenceEqual<T1, T2>(this IEnumerable<T1> items, IEnumerable<T2> other, Func<T1, T2, bool> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (other == null) throw new ArgumentNullException("other");

            var iterator1 = items.GetEnumerator();
            var iterator2 = other.GetEnumerator();

            while (iterator1.MoveNext())
            {
                if (!iterator2.MoveNext())
                    return false;

                if (!predicate.Invoke(iterator1.Current, iterator2.Current))
                    return false;
            }
            if (iterator2.MoveNext())
                return false;

            return true;
        }

        [Obsolete("Use the overload of SequenceEqual with the exact same arguments.")]
        public static bool MapsTo<T1, T2>(this IEnumerable<T1> items, IEnumerable<T2> other, Func<T1, T2, bool> predicate)
        {
            return items.SequenceEqual(other, predicate);
        }

        /// <summary>
        /// Determines whether the given sequence is a permutation of another.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool IsPermutationOf<T>(this IEnumerable<T> items, IEnumerable<T> other)
            where T : struct
        {
            if (items == null) throw new ArgumentNullException("items");
            if (other == null) throw new ArgumentNullException("other");

            var list1 = items.ToList();
            var list2 = other.ToList();

            if(list1.Count == 0 || list2.Count == 0) 
                return list1.Count == 0 && list2.Count == 0;            

            list1.Sort();
            list2.Sort();

            return list1.SequenceEqual(list2);
        }

        /// <summary>
        /// Returns a pseudorandom permutation of the given sequence. It may happen to be equal to the original.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException("items");

            var seq = RandomSequence(0, items.Count());
            return seq.Select(x => items.ElementAt(x));                        
        }

        private static readonly Random RandomNumberGenerator = new Random();
        private static IEnumerable<int> RandomSequence(int minimum, int maximum)
        {            
            var candidates = Enumerable.Range(minimum, maximum - minimum).ToList();

            while (candidates.Count > 0)
            {
                var index = RandomNumberGenerator.Next(candidates.Count);
                yield return candidates[index];
                candidates.RemoveAt(index);
            }
        }
			
        /// <summary>
        /// Returns a sequence containing only the given item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToUnarySequence<T>(this T item)
        {
            return new[] {item};
        }

        /// <summary>
        /// Returns the union of the given sequence and the given item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="extraItem"></param>
        /// <returns></returns>
        public static IEnumerable<T> Union<T>(this IEnumerable<T> items, T extraItem)
        {
            return items.Union(extraItem.ToUnarySequence());
        }

        /// <summary>
        /// Invokes the action on the given class instance if it's not null, otherwise does nothing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static void IfNotDefault<T>(this T item, Action<T> action)
            where T : class
        {
            if (action == null) throw new ArgumentNullException("action");

            if (item != null) action.Invoke(item);
        }
        
		/// <summary>
		/// Concat the specified sequence and one more item.
		/// </summary>
		/// <param name="items"></param>
		/// <param name="addition"></param>
		/// <typeparam name="T"></typeparam>
		public static IEnumerable<T> Concat<T>(this IEnumerable<T> items, T addition)
		{
			foreach (var i in items)
				yield return i;
			yield return addition;
		}

		/// <summary>
		/// Prepare to apply the specified action to the sequence or part of the sequence.
		/// </summary>
		/// <param name="items"></param>
		/// <param name="action"></param>
		/// <typeparam name="T"></typeparam>
		public static ActionApplyingEnumerable<T> Apply<T>(this IEnumerable<T> items, Action<T> action)
		{
			if (items == null)
				throw new ArgumentNullException ("items");
			if (action == null)
				throw new ArgumentNullException ("action");

			return new ActionApplyingEnumerable<T> (items, action);
		}

		/// <summary>
		/// Apply the previously specified action to all elements.
		/// </summary>
		/// <param name="items"></param>
		/// <typeparam name="T"></typeparam>
		public static void ToAll<T>(this ActionApplyingEnumerable<T> items)
		{
			if (items == null)
				throw new ArgumentNullException ("items");

			foreach (var a in items.Sequence)
				items.Action.Invoke (a);
		}

		/// <summary>
		/// Apply the previously specified action to all elements except the last one.
		/// </summary>
		/// <param name="items"></param>
		/// <typeparam name="T"></typeparam>
		public static void ToAllExceptLast<T>(this ActionApplyingEnumerable<T> items)
		{
			if (items == null)
				throw new ArgumentNullException ("items");

			foreach (var a in items.Sequence.ButLast())
				items.Action.Invoke (a);
		}

		/// <summary>
		/// Apply the previously specified action to all elements and then applies an additional action to the last one.
		/// </summary>
		/// <param name="items">Items.</param>
		/// <param name="action">Action.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static void ToAllAndThenApplyToLast<T>(this ActionApplyingEnumerable<T> items, Action<T> action)
		{
			if (items == null)
				throw new ArgumentNullException ("items");

			var outer = default(T);
			foreach (var a in items.Sequence) {
				outer = a;
				items.Action.Invoke (a);
			}
			action.Invoke(outer);
		}

		/// <summary>
		/// Apply the previously specified action to all elements except the last and then apply a different action to the last one.
		/// </summary>
		/// <param name="items"></param>
		/// <param name="action"></param>
		/// <typeparam name="T"></typeparam>
		public static void ToAllWithDifferentLast<T>(this ActionApplyingEnumerable<T> items, Action<T> action)
		{
			if (items == null)
				throw new ArgumentNullException ("items");

			var collection = items.Sequence.ToArray ();
			foreach (var a in collection.ButLast())
				items.Action.Invoke (a);
			action.Invoke (collection.Last ());
		}

		public static IEnumerable<T> Before<T>(this IEnumerable<T> items, T item)
		{
			if (items == null)
				throw new ArgumentNullException ("items");

			return items.TakeWhile (x => !(x.Equals(item)));
		}

		public static IEnumerable<T> TakeWhileAndNext<T>(this IEnumerable<T> items, Func<T, bool> predicate)
		{
			if (items == null)
				throw new ArgumentNullException ("items");

			foreach (var i in items)
			{
				yield return i;
				if (!predicate.Invoke (i))
					yield break;
			}
		}

		/// <summary>
		/// Returns elements such that at least a given threshold is met when accumulating values using a provided selector. The threshold and the selector must be of the same type and must implement addition and comparison through operators.
		/// </summary>
		/// <returns>The at least.</returns>
		/// <param name="items">Items.</param>
		/// <param name="threshold">Threshold.</param>
		/// <param name="selector">Selector.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		/// <typeparam name="TSum">The 2nd type parameter.</typeparam>
		public static IEnumerable<T> AccumulateAtLeast<T, TSum>(this IEnumerable<T> items, TSum threshold, Func<T, TSum> selector)
		{
			if (items == null)
				throw new ArgumentNullException ("items");

			TSum sum = default(TSum);
			return items.TakeWhileAndNext (x => {
				sum = sum.OperatorPlus(selector.Invoke(x));
				return !sum.OperatorGreaterThan(threshold);
			});
		}
    }

    /// <summary>
    /// A helper type returned by the NotOf() extension method, to support
    /// the NotOf().Type() syntax.
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


	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ActionApplyingEnumerable<T>
	{
		internal IEnumerable<T> Sequence { get; private set; }
		internal Action<T> Action { get; private set; }

		public ActionApplyingEnumerable(IEnumerable<T> sequence, Action<T> action)
		{
			Sequence = sequence;
			Action = action;
		}
	}
}
