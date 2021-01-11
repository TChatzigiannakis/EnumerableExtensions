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

    public static partial class EnumerableExtensions
    {
        #region [Interface]

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        public static IEnumerable<T> AccumulateAtLeast<T, TSum>(
            this IEnumerable<T> sequence,
            TSum threshold,
            Func<T, TSum> selector) => AccumulateAtLeastImpl(
                sequence ?? throw new ArgumentNullException(nameof(sequence)),
                threshold,
                selector ?? throw new ArgumentNullException(nameof(selector)));

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        public static IEnumerable<T> AccumulateAtLeast<T>(
            this IEnumerable<T> sequence,
            int threshold,
            Func<T, int> selector) => AccumulateAtLeastImpl(
                sequence ?? throw new ArgumentNullException(nameof(sequence)),
                threshold,
                selector ?? throw new ArgumentNullException(nameof(selector)));

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> AccumulateAtLeast<T>(
            this IEnumerable<T> sequence,
            decimal threshold,
            Func<T, decimal> selector) => AccumulateAtLeastImpl(
                sequence ?? throw new ArgumentNullException(nameof(sequence)),
                threshold,
                selector ?? throw new ArgumentNullException(nameof(selector)));

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        public static IEnumerable<T> AccumulateAtLeast<T>(
            this IEnumerable<T> sequence,
            byte threshold,
            Func<T, byte> selector) => AccumulateAtLeastImpl(
                sequence ?? throw new ArgumentNullException(nameof(sequence)),
                threshold,
                selector ?? throw new ArgumentNullException(nameof(selector)));

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        public static IEnumerable<T> AccumulateAtLeast<T>(
            this IEnumerable<T> sequence,
            int threshold,
            Func<T, byte> selector) => AccumulateAtLeastImpl(
                sequence ?? throw new ArgumentNullException(nameof(sequence)),
                threshold,
                selector ?? throw new ArgumentNullException(nameof(selector)));

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        public static IEnumerable<T> AccumulateAtLeast<T>(
            this IEnumerable<T> sequence,
            float threshold,
            float epsilon,
            Func<T, float> selector) => AccumulateAtLeastImpl(
                sequence ?? throw new ArgumentNullException(nameof(sequence)),
                threshold,
                epsilon,
                selector ?? throw new ArgumentNullException(nameof(selector)));

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        public static IEnumerable<T> AccumulateAtLeast<T>(
            this IEnumerable<T> sequence,
            float threshold,
            Func<T, float> selector) => AccumulateAtLeastImpl(
                sequence ?? throw new ArgumentNullException(nameof(sequence)),
                threshold,
                selector ?? throw new ArgumentNullException(nameof(selector)));

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        public static IEnumerable<T> AccumulateAtLeast<T>(
            this IEnumerable<T> sequence,
            double threshold,
            double epsilon,
            Func<T, double> selector) => AccumulateAtLeastImpl(
                sequence ?? throw new ArgumentNullException(nameof(sequence)),
                threshold,
                epsilon,
                selector ?? throw new ArgumentNullException(nameof(selector)));

        /// <summary>
        /// Returns elements required to meet a given threshold by accumulating values using a provided selector.
        /// </summary>
        public static IEnumerable<T> AccumulateAtLeast<T>(
            this IEnumerable<T> sequence,
            double threshold,
            Func<T, double> selector) => AccumulateAtLeastImpl(
                sequence ?? throw new ArgumentNullException(nameof(sequence)),
                threshold,
                selector ?? throw new ArgumentNullException(nameof(selector)));

        #endregion

        #region [Implementations]

        private static IEnumerable<T> AccumulateAtLeastImpl<T, TSum>(
            IEnumerable<T> sequence,
            TSum threshold,
            Func<T, TSum> selector)
        {
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

        private static IEnumerable<T> AccumulateAtLeastImpl<T>(
            IEnumerable<T> sequence,
            int threshold,
            Func<T, int> selector)
        {
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

        private static IEnumerable<T> AccumulateAtLeastImpl<T>(
            IEnumerable<T> sequence,
            decimal threshold,
            Func<T, decimal> selector)
        {
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

        private static IEnumerable<T> AccumulateAtLeastImpl<T>(
            IEnumerable<T> sequence,
            byte threshold,
            Func<T, byte> selector)
        {
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

        private static IEnumerable<T> AccumulateAtLeastImpl<T>(
            IEnumerable<T> sequence,
            int threshold,
            Func<T, byte> selector)
        {
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

        private static IEnumerable<T> AccumulateAtLeastImpl<T>(
            IEnumerable<T> sequence,
            float threshold,
            float epsilon,
            Func<T, float> selector)
        {
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

        private static IEnumerable<T> AccumulateAtLeastImpl<T>(
            IEnumerable<T> sequence,
            float threshold,
            Func<T, float> selector)
        {
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

        private static IEnumerable<T> AccumulateAtLeastImpl<T>(
            IEnumerable<T> sequence,
            double threshold,
            double epsilon,
            Func<T, double> selector)
        {
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

        private static IEnumerable<T> AccumulateAtLeastImpl<T>(
            IEnumerable<T> sequence,
            double threshold,
            Func<T, double> selector)
        {
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

        #endregion
    }
}
