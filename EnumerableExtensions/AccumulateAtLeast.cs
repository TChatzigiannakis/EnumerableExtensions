/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 * 
 * Copyright (C) 2014  Theodoros Chatzigiannakis
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumerableExtensions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <param name="threshold"></param>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TSum"></typeparam>
        public static IEnumerable<T> AccumulateAtLeast<T, TSum>(this IEnumerable<T> sequence, TSum threshold, Func<T, TSum> selector)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (selector == null) throw new ArgumentNullException("selector");

            var sum = default(TSum);
            var iterator = sequence.GetEnumerator();
            while (sum.OperatorLessThan(threshold))
            {
                if (iterator.MoveNext())
                {
                    sum = sum.OperatorPlus(selector.Invoke(iterator.Current));
                    yield return iterator.Current;
                }
                else yield break;
            }
        }

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <param name="threshold"></param>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> AccumulateAtLeast<T>(this IEnumerable<T> sequence, int threshold, Func<T, int> selector)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (selector == null) throw new ArgumentNullException("selector");

            var sum = default(int);
            var iterator = sequence.GetEnumerator();
            while (sum < threshold)
            {
                if (iterator.MoveNext())
                {
                    sum += selector.Invoke(iterator.Current);
                    yield return iterator.Current;
                }
                else yield break;

            }
        }

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <param name="threshold"></param>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> AccumulateAtLeast<T>(this IEnumerable<T> sequence, decimal threshold, Func<T, decimal> selector)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (selector == null) throw new ArgumentNullException("selector");

            var sum = default(decimal);
            var iterator = sequence.GetEnumerator();
            while (sum < threshold)
            {
                if (iterator.MoveNext())
                {
                    sum += selector.Invoke(iterator.Current);
                    yield return iterator.Current;
                }
                else yield break;
            }
        }

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <param name="threshold"></param>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> AccumulateAtLeast<T>(this IEnumerable<T> sequence, byte threshold, Func<T, byte> selector)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (selector == null) throw new ArgumentNullException("selector");

            var sum = default(int);
            var iterator = sequence.GetEnumerator();
            while (sum < threshold)
            {
                if (iterator.MoveNext())
                {
                    sum += selector.Invoke(iterator.Current);
                    yield return iterator.Current;
                }
                else yield break;
            }
        }

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <param name="threshold"></param>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> AccumulateAtLeast<T>(this IEnumerable<T> sequence, int threshold, Func<T, byte> selector)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (selector == null) throw new ArgumentNullException("selector");

            var sum = default(int);
            var iterator = sequence.GetEnumerator();
            while (sum < threshold)
            {
                if (iterator.MoveNext())
                {
                    sum += selector.Invoke(iterator.Current);
                    yield return iterator.Current;
                }
                else yield break;
            }
        }

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <param name="threshold"></param>
        /// <param name="epsilon"></param>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> AccumulateAtLeast<T>(this IEnumerable<T> sequence, float threshold, float epsilon, Func<T, float> selector)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (selector == null) throw new ArgumentNullException("selector");

            var sum = default(float);
            var iterator = sequence.GetEnumerator();
            while (threshold - sum < epsilon)
            {
                if (iterator.MoveNext())
                {
                    sum += selector.Invoke(iterator.Current);
                    yield return iterator.Current;
                }
                else yield break;
            }
        }

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <param name="threshold"></param>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> AccumulateAtLeast<T>(this IEnumerable<T> sequence, float threshold, Func<T, float> selector)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (selector == null) throw new ArgumentNullException("selector");

            var sum = default(decimal);
            var iterator = sequence.GetEnumerator();
            while (sum < (decimal)threshold)
            {
                if (iterator.MoveNext())
                {
                    sum += (decimal)selector.Invoke(iterator.Current);
                    yield return iterator.Current;
                }
                else yield break;
            }
        }

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <param name="threshold"></param>
        /// <param name="epsilon"></param>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> AccumulateAtLeast<T>(this IEnumerable<T> sequence, double threshold, double epsilon, Func<T, double> selector)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (selector == null) throw new ArgumentNullException("selector");

            var sum = default(double);
            var iterator = sequence.GetEnumerator();
            while (threshold - sum < epsilon)
            {
                if (iterator.MoveNext())
                {
                    sum += selector.Invoke(iterator.Current);
                    yield return iterator.Current;
                }
                else yield break;
            }
        }

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        /// <returns></returns>
        /// <param name="sequence"></param>
        /// <param name="threshold"></param>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> AccumulateAtLeast<T>(this IEnumerable<T> sequence, double threshold, Func<T, double> selector)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (selector == null) throw new ArgumentNullException("selector");

            var sum = default(decimal);
            var iterator = sequence.GetEnumerator();
            while (sum < (decimal)threshold)
            {
                if (iterator.MoveNext())
                {
                    sum += (decimal)selector.Invoke(iterator.Current);
                    yield return iterator.Current;
                }
                else yield break;
            }
        }
    }
}
