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
        /// Returns all sequences that are permutations of the given sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null) throw new ArgumentNullException();

            var list = sequence.ToList();

            if (list.IsEmpty())
                yield return list;
            else
            {
                var index = 0;
                foreach (var head in list)
                {
                    var indexInClosure = index;
                    var rest = list.Except((x, i) => indexInClosure == i);
                    var permutationsOfRest = rest.Permutations();
                    foreach (var permutation in permutationsOfRest)
                        yield return head.ToUnarySequence().Concat(permutation);
                    index++;
                }
            }
        }

    }
}
